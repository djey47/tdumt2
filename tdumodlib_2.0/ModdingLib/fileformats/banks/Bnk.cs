using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using log4net;
using ModdingLibrary_2.support;
using Fesersoft.Hashing;

namespace ModdingLibrary_2.fileformats.banks
{
    /// <summary>
    /// Represents BNK file format (TDU2 banks)
    /// </summary>
    public class Bnk : AbstractFile
    {
        #region Constants
        /// <summary>
        /// BNK TAG : KNAB
        /// </summary>
        private static readonly byte[] _TAG_BNK = new byte[] { 0x4B, 0x4E, 0x41, 0x42 };

        /// <summary>
        /// Value for TDU2 entry in file info section
        /// </summary>
        private const uint _SIXTEEN = 16;

        /// <summary>
        /// Maximum size for packed files names hierarchy
        /// </summary>
        private const int _PACKED_TREE_MAX_SIZE = 1048576;

        /// <summary>
        /// Size of each section header, in bytes (section length, crc)
        /// </summary>
        private const uint _SECTION_HEADER_LENGTH = 8;

        /// <summary>
        /// Data size for BNK header, in bytes
        /// </summary>
        private const uint _HEADER_LENGTH = 64;

        /// <summary>
        /// Size of type mapping entry, in bytes
        /// </summary>
        private const uint _MAPPING_ENTRY_LENGTH = 4;

        /// <summary>
        /// Size of address entry (TDU), in bytes
        /// </summary>
        private const int _ADDRESS_ENTRY_TDU_LENGTH = 16;

        /// <summary>
        /// Size of address entry (TDU), in bytes
        /// </summary>
        private const int _ADDRESS_ENTRY_TDU2_LENGTH = 20;

        /// <summary>
        /// Weird padding sentence.
        /// Original : STNICC2000 RULEZPADDING DATAS...-ORIC AND ATARI--COOL  MACHINES-
        /// New: TDUMTII-UNBIN-BRAVO LES POTES-EPIC-
        /// </summary>
        //private const string _PADDING_STRING = "STNICC2000 RULEZPADDING DATAS...-ORIC AND ATARI--COOL  MACHINES-";
        private const string _PADDING_STRING = "TDUMTII-UNBIN-BRAVO LES POTES-EPIC-";

        /// <summary>
        /// Mask used to compute properly count of packed files within a packed directory (when more than 127 items)
        /// (short) Count = (short) readCount XOR (short) mask
        /// FIXME This has to be clarified
        /// </summary>
        private const short _HIGH_PACKED_FILE_COUNT_MASK = 0x380;
        #endregion

        #region Technical members
        /// <summary>
        /// Internal logger
        /// </summary>
        private static readonly ILog _Log = LogManager.GetLogger(typeof(Bnk));
        #endregion

        #region Bnk structure
        /// <summary>
        /// Generic section
        /// </summary>
        struct Section
        {
            public uint address;
            public uint length;
            public uint checksum;
            public byte[] data;
        }

        /// <summary>
        /// Packed file information in file size&address section + type mapping section (optional)
        /// </summary>
        struct PackedFileInfo
        {
            public uint address;
            public uint size;
            public ulong magic;
            public uint type;
        }
        #endregion

        #region Bnk data (private)
        /// <summary>
        /// Special flag #1. Should never change.
        /// </summary>
        private ushort _SpecialFlag1;

        /// <summary>
        /// Special flag #2. Should never change.
        /// </summary>
        private ushort _SpecialFlag2;

        /// <summary>
        /// File size. Only updated when saving.
        /// </summary>
        private uint _FileSize;

        /// <summary>
        /// Size of packed contents. Updated when repacking.
        /// </summary>
        private uint _PackedSize;

        /// <summary>
        /// Size of paddding between packed contents. Updated when saving.
        /// </summary>
        private uint _PackedPaddingSize;

        /// <summary>
        /// Size of block #1. Should never change.
        /// </summary>
        private uint _BlockSize1;

        /// <summary>
        /// Size of block #2. Should never change.
        /// </summary>
        private uint _BlockSize2;

        /// <summary>
        /// Packed file count. Updated when repacking.
        /// </summary>
        private uint _PackedCount;

        /// <summary>
        /// Year. Updated when saving.
        /// </summary>
        private uint _Year;

        /// <summary>
        /// Address of sizes section as read in header.
        /// </summary>
        private uint _SizeSectionAddr;

        /// <summary>
        /// Address of type mapping section as read in header.
        /// </summary>
        private uint _TypeMappingSectionAddr;

        /// <summary>
        /// Address of name section as read in header.
        /// </summary>
        private uint _TreeSectionAddr;

        /// <summary>
        /// Address of order section as read in header.
        /// </summary>
        private uint _OrderSectionAddr;

        /// <summary>
        /// Address of unk2 section as read in header.
        /// </summary>
        private uint _Unknown2SectionAddr;

        /// <summary>
        /// Address of data section as read in header.
        /// </summary>
        private uint _DataSectionAddr;

        #endregion

        #region Bnk data (public)
        /// <summary>
        /// All packed files
        /// </summary>
        /// <returns></returns>
        public List<PackedFile> PackedFiles { get { return _PackedFileByIdIndex.Values.ToList(); } } 
        
        /// <summary>
        /// Root entry for file hierarchy
        /// </summary>
        public PackedFolder PackedRoot { get; private set; }

        /// <summary>
        /// Game version of this BNK
        /// </summary>
        public Context.Product Version { get; private set;}
        #endregion

        #region Indexes & Caches
        /// <summary>
        /// Type mapping cache for current Bnk
        /// extension is the key, file type is the value
        /// </summary>
        private readonly Dictionary<string, uint> _FileTypeByExtension = new Dictionary<string, uint>();

        /// <summary>
        /// id is the key, packed file is the value
        /// </summary>
        private readonly Dictionary<uint, PackedFile> _PackedFileByIdIndex = new Dictionary<uint, PackedFile>();
        #endregion

        #region Sections
        private Section _TreeSection;
        private Section _OrderSection;
        private Section _Unknown2Section;
        private Section _SizeSection;
        private Section _HeaderSection;
        private Section _TypeMappingSection;
        #endregion

        #region Operations
        /// <summary>
        /// Extracts all packed files and folders. Existing files will be replaced.
        /// </summary>
        /// <param name="targetFolder"></param>
        public void ExtractAll(string targetFolder)
        {
            try
            {
                // Browses all files. Order is not important.
                foreach (PackedFile file in _PackedFileByIdIndex.Values)
                {
                    string targetFileName = targetFolder + @"\" + file.Name;

                    Extract(file, targetFileName);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error when extracting from BNK.", e);
            }
        }

        /// <summary>
        /// Extracts specified packed file to disk.
        /// </summary>
        /// <param name="packedFile"></param>
        /// <param name="targetFilePath"></param>
        public static void Extract(PackedFile packedFile, string targetFilePath)
        {
            if (packedFile != null)
            {
                using (
                    BinaryWriter fileWriter =
                        new BinaryWriter(new FileStream(targetFilePath, FileMode.Create, FileAccess.Write)))
                {
                    fileWriter.Write(packedFile.Data);
                }
            }
        }

        /// <summary>
        /// Retrieves a packed file with specified identifier.
        /// </summary>
        /// <param name="id">internal file identifier in hierarchy</param>
        /// <returns>null if packed file has not been found </returns>
        public PackedFile GetPackedFile(uint id)
        {
            // Should never crash
            PackedFile returnedFile = null;

            if (_PackedFileByIdIndex.ContainsKey(id))
            {
                returnedFile = _PackedFileByIdIndex[id];
            }

            return returnedFile;
        }

        /// <summary>
        /// Repacks contents of specified folder to current bank
        /// </summary>
        /// <param name="folder"></param>
        public void Repack(string folder)
        {
            try
            {
                if (!Directory.Exists(folder))
                {
                    throw new Exception("Folder does not exist: " + folder);
                }

                // Start node
                PackedFolder startNode = PackedRoot;
                for (int i = 0 ; i < 4 ; i++)
                {
                    startNode = startNode.Children[0];
                }

                // Rebuilds hierarchy from specified folder
                List<PackedFile> packedFilesReference = _PackedFileByIdIndex.Values.ToList();
                _PackedFileByIdIndex.Clear();
                _PackedSize = _PackedPaddingSize = 0;
                _RebuildTree(startNode, folder, packedFilesReference);

                // Attribute update
                _PackedCount = (uint) _PackedFileByIdIndex.Count;

                // Sections update in memory
                _TypeMappingSection = new Section();
                if (_TypeMappingSectionAddr != 0)
                {
                    _TypeMappingSection = _UpdateTypeMappingSection();
            }
                _TreeSection = _UpdateTreeSection();
                _OrderSection = _UpdateOrderSection();
                _Unknown2Section = new Section();
                if (_Unknown2SectionAddr != 0)
                {
                    _Unknown2Section = _UpdateUnknown2Section();
                }
                // BNK Header
                int usefulSize = (int)(_SECTION_HEADER_LENGTH + _HEADER_LENGTH);
                int lastSectionSize = usefulSize + _ComputePaddingLength(usefulSize, (int)_BlockSize1);
                // Sizes&addresses
                _SizeSectionAddr = (uint)lastSectionSize;
                uint entrySize = (uint)(Version == Context.Product.TDU ? _ADDRESS_ENTRY_TDU_LENGTH : _ADDRESS_ENTRY_TDU2_LENGTH);
                uint addressAndSizesLength = entrySize * (_PackedCount + 1);
                usefulSize = (int)(_SECTION_HEADER_LENGTH + addressAndSizesLength);
                lastSectionSize = usefulSize + _ComputePaddingLength((int)_SizeSectionAddr + usefulSize, (int)_BlockSize1);
                // Type mapping
                if (_TypeMappingSectionAddr != 0)
                {
                    _TypeMappingSectionAddr = (uint)(_SizeSectionAddr + lastSectionSize);
                    _TypeMappingSection.address = _TypeMappingSectionAddr;
                    entrySize = 4;
                    usefulSize = (int)(_SECTION_HEADER_LENGTH + entrySize * _PackedCount);
                    lastSectionSize = usefulSize + _ComputePaddingLength((int)_TypeMappingSectionAddr + usefulSize, (int)_BlockSize1);
                    // File tree
                    _TreeSectionAddr = (uint)(_TypeMappingSectionAddr + lastSectionSize);
                }
                else
                {
                    // File tree
                    _TreeSectionAddr = (uint)(_SizeSectionAddr + lastSectionSize);
                }
                // File tree - part 2
                _TreeSection.address = _TreeSectionAddr;
                usefulSize = (int)(_SECTION_HEADER_LENGTH + _TreeSection.length);
                lastSectionSize = usefulSize + _ComputePaddingLength((int)_TreeSectionAddr + usefulSize, (int)_BlockSize1);
                // Orders : warning, values are of type short if more than 256 files !
                // Block size used is the same as for files...
                _OrderSectionAddr = (uint)(_TreeSectionAddr + lastSectionSize);
                _OrderSection.address = _OrderSectionAddr;
                if (_PackedCount > 256)
                {
                    usefulSize = (int)(_SECTION_HEADER_LENGTH + _PackedCount * 2);
                }
                else
                {
                    usefulSize = (int)(_SECTION_HEADER_LENGTH + _PackedCount);
                }
                lastSectionSize = usefulSize + _ComputePaddingLength((int)_OrderSectionAddr + usefulSize, (int)_BlockSize2);
                // Unknown
                if (_Unknown2SectionAddr != 0)
                {
                    _Unknown2SectionAddr = (uint)(_OrderSectionAddr + lastSectionSize);
                    _Unknown2Section.address = _Unknown2SectionAddr;
                    usefulSize = (int)(_SECTION_HEADER_LENGTH + _Unknown2Section.length);
                    lastSectionSize = usefulSize + _ComputePaddingLength((int)_Unknown2SectionAddr + usefulSize, (int)_BlockSize1);
                    // Packed data
                    _DataSectionAddr = (uint)(_Unknown2SectionAddr + lastSectionSize);
                }
                else
                {
                    // Packed data
                    _DataSectionAddr = (uint)(_OrderSectionAddr + lastSectionSize);
                }

                // Updated section : adresses and sizes of packed files
                _SizeSection = _UpdateSizeSection();

                // Header section is updated the last
                _FileSize = _DataSectionAddr + _PackedSize + _PackedPaddingSize;
                _Year = (uint)DateTime.Now.Year;
                _HeaderSection = _UpdateHeaderSection();
            }
            catch (Exception e)
            {
                throw new Exception("Repack failed.",e);
            }
        }

        /// <summary>
        /// Recursive method parsing filesystem to rebuild folders and file hierarchy
        /// </summary>
        /// <param name="startNode">current packed folder into BNK</param>
        /// <param name="folder">current folder from disk</param>
        /// <param name="packedFilesReference">previous packed files list to get information</param>
        private void _RebuildTree(PackedFolder startNode, string folder, IEnumerable<PackedFile> packedFilesReference)
        {
            DirectoryInfo di = new DirectoryInfo(folder);
            DirectoryInfo[] subDirectories = di.GetDirectories();
            FileInfo[] files = di.GetFiles();

            // Initializes contents of current packed folder
            startNode.Children = new List<PackedFolder>();

            // Files - must be grouped per extension first
            if (files.Length > 0)
            {
                IEnumerable<FileInfo> groupedFiles = _GroupFilesByExtension(di);

                foreach (FileInfo file in groupedFiles)
                {
                    // Creates an extension folder, if necessary
                    string extension = Path.GetExtension(file.Name);
                    PackedFolder packedFolder = _RetrieveExtensionFolder(extension, startNode);

                    if (!startNode.Children.Contains(packedFolder))
                    {
                        startNode.Children.Add(packedFolder);
                    }

                    // Packed file & attributes
                    byte[] data = File.ReadAllBytes(file.FullName);
                    PackedFile packedFile = new PackedFile
                                       {
                                           Name = file.Name,
                                           Id = (uint) _PackedFileByIdIndex.Count,
                                           Data = data,
                                           FullPath = string.Concat(packedFolder.FullPath, PackedFile.PATH_SEPARATOR, Path.GetFileNameWithoutExtension(file.Name)),
                                           PaddingSize = _ComputePaddingLength(data.Length, (int)_BlockSize2),
                                           Type =  _GetFileTypeFromExtension(extension) // Default value
                                       };
                    // If exist in current BNK, previous magic and type values are used
                    foreach (PackedFile item in packedFilesReference.Where(item => item.FullPath.Equals(packedFile.FullPath, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        packedFile.Magic = item.Magic;
                        packedFile.Type = item.Type;
                        break;
                    }
                    
                    // Updates total sizes
                    _PackedPaddingSize += (uint) packedFile.PaddingSize;
                    _PackedSize += (uint)packedFile.Data.Length;

                    // Adds this packed file to file hierarchy
                    packedFolder.Children.Add(packedFile);

                    // Index update
                    _PackedFileByIdIndex.Add(packedFile.Id, packedFile);
                }
            }

            // Directories
            foreach (DirectoryInfo subDir in subDirectories)
            {
                PackedFolder pf = new PackedFolder { Name = subDir.Name,
                                                     FullPath = string.Concat(startNode.FullPath, PackedFile.PATH_SEPARATOR, subDir.Name)
                };

                // Adds this packed folder to file hierarchy
                startNode.Children.Add(pf);

                // Continue processing to this folder
                _RebuildTree(pf, subDir.FullName, packedFilesReference);
            }
        }
        #endregion

        #region Private methods - read
        /// <summary>
        /// Reads header section
        /// </summary>
        /// <param name="reader"></param>
        private void _ReadHeaderSection(BinaryReader reader)
        {
            _HeaderSection = _ReadGenericSection(reader, 0);

            using (BinaryReader dataReader = new BinaryReader(new MemoryStream(_HeaderSection.data)))
            {
                // Unused data
                dataReader.ReadBytes(0xC);

                // Special flags
                _SpecialFlag1 = dataReader.ReadUInt16();
                _SpecialFlag2 = dataReader.ReadUInt16();

                // Sizes
                _FileSize = dataReader.ReadUInt32();
                _PackedSize = dataReader.ReadUInt32();
                _BlockSize1 = dataReader.ReadUInt32(); // 4 or 32 only (all tdu2-last update dlc 2 bnk scanned)
                _BlockSize2 = dataReader.ReadUInt32(); // always 16 (all tdu2-last update dlc 2 bnk scanned)

                _PackedCount = dataReader.ReadUInt32();
                _Year = dataReader.ReadUInt32();

                // Section addresses
                _SizeSectionAddr = dataReader.ReadUInt32();
                _TypeMappingSectionAddr = dataReader.ReadUInt32();
                _TreeSectionAddr = dataReader.ReadUInt32();
                _OrderSectionAddr = dataReader.ReadUInt32();
                _Unknown2SectionAddr = dataReader.ReadUInt32();
                _DataSectionAddr = dataReader.ReadUInt32();
            }
        }

        /// <summary>
        /// Reads sizes section
        /// </summary>
        /// <param name="reader"></param>
        private List<PackedFileInfo> _ReadSizeSection(BinaryReader reader)
        {
            List<PackedFileInfo> sizeList = new List<PackedFileInfo>();

            _SizeSection = _ReadGenericSection(reader, _SizeSectionAddr);

            // Detecting BNK version automatically
            int entrySize = (int)(_SizeSection.length / (_PackedCount + 1));

            if (entrySize == _ADDRESS_ENTRY_TDU_LENGTH)
            {
                Version = Context.Product.TDU;
            }
            else if (entrySize == _ADDRESS_ENTRY_TDU2_LENGTH)
            {
                Version = Context.Product.TDU2;
            }
            else
            {
                _Log.Error("Unknown address entry length="  + entrySize + " bytes");
            }

            using (BinaryReader dataReader = new BinaryReader(new MemoryStream(_SizeSection.data)))
            {
                // Last entry is just there to delimitate end of data
                uint actualPackedSize = 0;
                for (int i = 0; i < _PackedCount + 1; i++)
                {
                    PackedFileInfo info = new PackedFileInfo
                                              {
                                                  address = dataReader.ReadUInt32(),
                                                  size = dataReader.ReadUInt32(),
                                                  magic = dataReader.ReadUInt64()
                                              };

                    actualPackedSize += info.size;

                    // TDU2: Entry is now 20 bytes...
                    if (Version == Context.Product.TDU2)
                    {
                        // Always value uint=16
                        dataReader.ReadUInt32();
                    }

                    sizeList.Add(info);
                }

                // Check total file size vs header information
                _Log.Info("Size of packed contents: header=" + _PackedSize + ", actual=" + actualPackedSize);

                if (_PackedSize != actualPackedSize)
                {
                    _Log.Warn("Packed contents size mismatch !");
                }
            }

            return sizeList;
        }

        /// <summary>
        /// Gets all packed files and their contents from 3 sections
        /// </summary>
        /// <param name="reader"></param>
        private void _ReadPackedData(BinaryReader reader)
        {
            // Index reinit
            _PackedFileByIdIndex.Clear();

            // Reads complementary sections
            List<PackedFileInfo> sizeAndAddressList = _ReadSizeSection(reader);
            List<uint> ordersList = _ReadOrderSection(reader);

            // Reads type mapping data
            if (_TypeMappingSectionAddr != 0)
            {
                List<uint> typeList = _ReadTypeMappingSection(reader);

                // Updates file types
                for (int i = 0; i < typeList.Count; i++)
                {
                    PackedFileInfo currentInfo = sizeAndAddressList[i];
                    currentInfo.type = typeList[i];
                    sizeAndAddressList[i] = currentInfo;
                }
            }

            // Entry point: tree section to read
            PackedRoot = _ReadTreeSection(reader);
            
            // Gets data for each packed file. Order is not important.
            for (uint i = 0 ; i < _PackedFileByIdIndex.Count ; i++)
            {
                PackedFile currentFile = _PackedFileByIdIndex[i];

                // Retrieving file position
                uint position = ordersList[(int) i];

                // Retrieving file address and size
                PackedFileInfo currentInfo = sizeAndAddressList[(int)position];
                uint address = currentInfo.address;
                uint size = currentInfo.size;

                // Getting data
                reader.BaseStream.Seek(address, SeekOrigin.Begin);
                currentFile.Data = reader.ReadBytes((int)size);

                // Magic
                currentFile.Magic = currentInfo.magic;

                // Type
                currentFile.Type = currentInfo.type;
                // Type cache update
                // Warning, 2DM files for colors have a different id.... so using cache is not always reliable
                string extension = Path.GetExtension(currentFile.Name).ToUpper();

                if (!_FileTypeByExtension.ContainsKey(extension))
                {
                    _FileTypeByExtension.Add(extension, currentFile.Type);
                }
            }
        }

        /// <summary>
        /// Read file orders section
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private List<uint> _ReadOrderSection(BinaryReader reader)
        {
            List<uint> orderList = new List<uint>();

            _OrderSection = _ReadGenericSection(reader, _OrderSectionAddr);

            using (BinaryReader dataReader = new BinaryReader(new MemoryStream(_OrderSection.data)))
            {
                // If there are more than 256 files, values are short.
                bool isShortMode = (_PackedCount > 256);

                for (int i = 0; i < _PackedCount; i++)
                {
                    uint currentOrder = (isShortMode ? dataReader.ReadUInt16() :  dataReader.ReadByte());
                    orderList.Add(currentOrder);
                }
            }

            return orderList;
        }

        /// <summary>
        /// Reads folder and files hierarchy section and returns root folder
        /// </summary>
        /// <param name="reader"></param>
        private PackedFolder _ReadTreeSection(BinaryReader reader)
        {
            PackedFolder rootFolder;

            _TreeSection = _ReadGenericSection(reader, _TreeSectionAddr);

            using (BinaryReader dataReader = new BinaryReader(new MemoryStream(_TreeSection.data)))
            {
                rootFolder = _ReadPackedHierarchy(dataReader, "");
            }

            return rootFolder;
        }

        /// <summary>
        /// Recursive method to read entry tree
        /// </summary>
        /// <param name="localReader"></param>
        /// <param name="parentPath"></param>
        /// <param name="extension">extension to parse files</param>
        /// <returns></returns>
        private PackedFolder _ReadPackedHierarchy(BinaryReader localReader, string parentPath, string extension = null)
        {
            PackedFolder f;

            // According to parsing mode
            if (extension == null)
            {
                // Folder
                // Name length
                int length = (256 - localReader.ReadByte());
                // Children count
                // Warning! children count may be expressed either with either 1 or 2 bytes (to 127 then 128 to 32767) 
                short childrenCount = localReader.ReadByte();
                
                // Next byte: either
                // - a dot char if we have an extension group
                // - or first char of directory name
                // - or the 2nd byte of children count (where values 1 or 2 have been found)
                // TODO need also write support....
                int nextByte = localReader.ReadByte();
                if (nextByte < 0x2E || nextByte > 0x7A) // Typically processing non character values
                {
                    _Log.Debug($"(READER) WARN: next byte={nextByte}, recomputing children count with {_HIGH_PACKED_FILE_COUNT_MASK:X} mask...");
                    localReader.BaseStream.Seek(-2, SeekOrigin.Current);
                    short magicChildrenCount = localReader.ReadInt16();
                    childrenCount = (short) (magicChildrenCount ^ _HIGH_PACKED_FILE_COUNT_MASK);
                    _Log.Debug($"(READER)       ... effective childrenCount={childrenCount}");
                }
                else
                {
                    localReader.BaseStream.Seek(-1, SeekOrigin.Current);
                }
                
                // Name
                byte[] entryNameBytes = localReader.ReadBytes(length);
                string entryName = Encoding.ASCII.GetString(entryNameBytes);

                // Folder creation
                f = new PackedFolder { Children = new List<PackedFolder>(childrenCount), Name = entryName, FullPath = (parentPath + "/" + entryName) };
                _Log.Debug($"(READER) creating folder entry {entryName} <> {f.FullPath},");
                _Log.Debug($"         containing {childrenCount} children entries");

                // Gets extension for children files
                if (entryName.StartsWith("."))
                {
                    extension = entryName;
                }

                // Parsing children
                for (int i = 0; i < childrenCount; i++)
                {
                    PackedFolder anotherChild = _ReadPackedHierarchy(localReader, f.FullPath, extension);
                    f.Children.Add(anotherChild);
                }
            }
            else
            {
                // File
                // Name length
                int length = localReader.ReadByte();
                // Name
                byte[] entryNameBytes = localReader.ReadBytes(length);
                string entryName = Encoding.ASCII.GetString(entryNameBytes);

                // File creation 
                uint id = (uint)_PackedFileByIdIndex.Count;
                f = new PackedFile { Name = string.Concat(entryName, extension), FullPath = (parentPath + "/" + entryName), Id = id };

                // Index update
                _PackedFileByIdIndex.Add(id, (PackedFile) f);

                _Log.Debug($"(READER)    - Created file entry ({id}) {entryName}{extension}");
            }

            return f;
        }

        /// <summary>
        /// Reads type mapping section, present in some files
        /// </summary>
        /// <param name="reader"></param>
        private List<uint> _ReadTypeMappingSection(BinaryReader reader)
        {
            List<uint> typeList = new List<uint>();
            _TypeMappingSection = _ReadGenericSection(reader, _TypeMappingSectionAddr);

            // Gets data for each file
            using (BinaryReader dataReader = new BinaryReader(new MemoryStream(_TypeMappingSection.data)))
            {
                int entryCount = (int)(_TypeMappingSection.data.Length / _MAPPING_ENTRY_LENGTH);

                for (uint i = 0; i < entryCount; i++)
                {
                    typeList.Add(dataReader.ReadUInt32());
                }
            }
            return typeList;
        }

        /// <summary>
        /// Reads other unknown section - very rare
        /// </summary>
        private void _ReadUnknown2Section(BinaryReader reader)
        {
            _Unknown2Section = _ReadGenericSection(reader, _Unknown2SectionAddr);
            _Log.Warn("Unk section detected, contents : " + _Unknown2Section);
        }
        #endregion

        #region Private methods - write
        /// <summary>
        /// Updates header section in memory
        /// </summary>
        private Section _UpdateHeaderSection()
        {
            // Updated data
            byte[] headerData = new byte[0x40];
            using (BinaryWriter memWriter = new BinaryWriter(new MemoryStream(headerData)))
            {
                // Tag
                memWriter.Write(_TAG_BNK);

                // Unused data, 8 bytes
                memWriter.Write(new byte[8]);

                // Special flags : should not change
                memWriter.Write(_SpecialFlag1);
                memWriter.Write(_SpecialFlag2);

                // Sizes : must be updated before this method
                memWriter.Write(_FileSize);
                memWriter.Write(_PackedSize);

                // Should not change
                memWriter.Write(_BlockSize1);
                memWriter.Write(_BlockSize2);

                // Updated
                memWriter.Write(_PackedCount);

                // Should not change
                memWriter.Write(_Year);

                // Section addresses : to be updated before this method
                memWriter.Write(_SizeSectionAddr);
                memWriter.Write(_TypeMappingSectionAddr);
                memWriter.Write(_TreeSectionAddr);
                memWriter.Write(_OrderSectionAddr);
                memWriter.Write(_Unknown2SectionAddr);
                memWriter.Write(_DataSectionAddr);
            }

            // Recreates header section with updated information
            return new Section
                       {
                           address = 0,
                           length = (uint)headerData.Length,
                                            checksum = _ComputeChecksum(headerData),
                                            data = headerData
                                        };
        }

        /// <summary>
        /// Updates addr&size section in memory.
        /// _SizeSectionAddr must be updated first.
        /// </summary>
        /// <returns></returns>
        private Section _UpdateSizeSection()
        {
            // Updated data : 1 entry per file, 1 entry = 16 bytes (TDU1) or 20 bytes (TDU2)
            uint entrySize = (uint)(Version == Context.Product.TDU ? _ADDRESS_ENTRY_TDU_LENGTH : _ADDRESS_ENTRY_TDU2_LENGTH);

            // Padding file is taken into account
            byte[] addressData = new byte[entrySize * (_PackedCount + 1)];
            using (BinaryWriter memWriter = new BinaryWriter(new MemoryStream(addressData)))
            {
                uint packedFileAddress = _DataSectionAddr;

                foreach (KeyValuePair<uint, PackedFile> item in _PackedFileByIdIndex.OrderBy(key => key.Value.Id))
                {
                    PackedFile pf = item.Value;

                    // Address
                    memWriter.Write(packedFileAddress);

                    // Data size
                    memWriter.Write(pf.Size);

                    // Magic ??
                    memWriter.Write(pf.Magic);

                    // For TDU2
                    if (Version == Context.Product.TDU2)
                    {
                        memWriter.Write(_SIXTEEN);
                    }

                    // Next!
                    packedFileAddress += (uint)(pf.Size + pf.PaddingSize);
                }

                // Padding file
                // Address
                memWriter.Write(packedFileAddress);
                // Data size - ignored
                memWriter.Write((uint)0);
                // Magic - ignored
                memWriter.Write((ulong)0);
                // For TDU2
                if (Version == Context.Product.TDU2)
                {
                    memWriter.Write(_SIXTEEN);
                }
            }

            // Recreates section with updated information
            return _CreateGenericSection(addressData,_SizeSectionAddr);          
        }

        /// <summary>
        /// Updates packed tree section in memory
        /// </summary>
        /// <returns></returns>
        private Section _UpdateTreeSection()
        {
            // Size = set to maximum arbitrary, change limit if pbs
            byte[] addressData = new byte[_PACKED_TREE_MAX_SIZE];
            using (BinaryWriter memWriter = new BinaryWriter(new MemoryStream(addressData)))
            {
                _UpdatePackedEntry(memWriter, PackedRoot);
            }

            // Truncates array just after first 0 byte
            int index = 0;
            foreach (byte b in addressData)
            {
                index++;

                if (b == 0)
                {
                    break;
                }
            }

            byte[] finalData = new byte[index];          
            Array.Copy(addressData, finalData, index);

            // Recreates section with updated information
            return _CreateGenericSection(finalData,0);               
        }

        /// <summary>
        /// Recursive method writing packed folder to memory
        /// </summary>
        /// <param name="memWriter"></param>
        /// <param name="entry"></param>
        private static void _UpdatePackedEntry(BinaryWriter memWriter, PackedFolder entry)
        {
            // Folder or file ?
            if (entry.GetType() != typeof(PackedFile))
            {
                // Folder
                // Name length
                int length = entry.Name.Length;
                memWriter.Write((byte) (256 - length));
                // Children entries count
                short childrenCount = (short) entry.Children.Count;
                if (childrenCount > 127)
                {
                    // FIXME See comments in read part for high children count
                    short magicChildrenCount = (short) (childrenCount ^ _HIGH_PACKED_FILE_COUNT_MASK);
                    memWriter.Write(magicChildrenCount);
                }
                else
                {
                    memWriter.Write(childrenCount);
                }
                // Name
                byte[] entryNameBytes = Encoding.ASCII.GetBytes(entry.Name);
                memWriter.Write(entryNameBytes);

                // Recursive call for children
                if (entry.Children != null)
                {
                    // Entries must be processed by path else game may crash 
                    foreach (PackedFolder pf in entry.Children.OrderBy(key => key.FullPath))
                    {
                        _Log.Debug($"(WRITER) Processing child folder: {pf.FullPath}");
                        _UpdatePackedEntry(memWriter, pf);
                    }
                }
            }
            else
            {
                // File
                // Name is without extensions
                string shortName = Path.GetFileNameWithoutExtension(entry.Name);
                // Name length
                byte length = (byte)shortName.Length;
                memWriter.Write(length);
                // Name
                byte[] entryNameBytes = Encoding.ASCII.GetBytes(shortName);
                memWriter.Write(entryNameBytes);
            }

        }

        /// <summary>
        /// Updates order section contents into memory
        /// </summary>
        /// <returns></returns>
        private Section _UpdateOrderSection()
        {
            // Size = count of packed files if <= 256 files, else count * 2
            bool isShortMode = (_PackedCount > 256);

            byte[] data = new byte[isShortMode ? _PackedCount * 2 : _PackedCount];

            using (BinaryWriter memWriter = new BinaryWriter(new MemoryStream(data)))
            {
                // Entries must be processed by path else game may crash 
                foreach( KeyValuePair<uint, PackedFile> item in _PackedFileByIdIndex.OrderBy(key => key.Value.FullPath))
                {
                    PackedFile pf = item.Value;

                    // ushort if more than 256 files, else byte
                    if (isShortMode)
                    {
                        memWriter.Write((ushort)pf.Id);
                    }
                    else
                    {
                        memWriter.Write((byte)pf.Id);
                    }
                }
            }

            // Recreates section with updated information
            return _CreateGenericSection(data,0);  
        }

        /// <summary>
        /// Does nothing for the moment. Should write contents of Unk2 section into memory.
        /// </summary>
        /// <returns></returns>
        private static Section _UpdateUnknown2Section()
        {
            throw new NotImplementedException();   
        }

        /// <summary>
        /// Updates type mapping section contents into memory
        /// </summary>
        /// <returns></returns>
        private Section _UpdateTypeMappingSection()
        {
            // Size = 4 bytes * file count
            byte[] data = new byte[_MAPPING_ENTRY_LENGTH * _PackedCount];
            using (BinaryWriter memWriter = new BinaryWriter(new MemoryStream(data)))
            {
                // Entries must be processed by path else game may crash 
                foreach (KeyValuePair<uint, PackedFile> packedFile in _PackedFileByIdIndex.OrderBy(key => key.Value.FullPath))
                {
                    memWriter.Write(packedFile.Value.Type);
                }
            }

            // Recreates section with updated information
            return _CreateGenericSection(data,0);   
        }

        /// <summary>
        /// Writes packed files with provided binary writer.
        /// </summary>
        /// <param name="writer"></param>
        private void _WritePackedFiles(BinaryWriter writer)
        {
            foreach (PackedFile pf in _PackedFileByIdIndex.OrderBy(key => key.Value.Id).Select(item => item.Value))
            {
                writer.Write(pf.Data);
                // Padding
                writer.Write(_GetPaddingString(pf.PaddingSize));
            }
        }
        #endregion

        #region Utility methods
        /// <summary>
        /// Utility method grouping contained file entries per extension.
        /// </summary>
        /// <param name="di">Information about current directory</param>
        /// <returns></returns>
        private static IEnumerable<FileInfo> _GroupFilesByExtension(DirectoryInfo di)
        {
            FileInfo[] files = di.GetFiles();
            FileInfo[] groupedFiles = new FileInfo[files.Length];

            // Gets all extensions
            Collection<string> extensions = new Collection<string>();

            foreach (FileInfo file in files.Where(file => !extensions.Contains(file.Extension.ToUpper())))
            {
                extensions.Add(file.Extension.ToUpper());
            }

            int i = 0;

            foreach (FileInfo file in
                extensions.Select(extension => di.GetFiles("*" + extension)).SelectMany(currentFiles => currentFiles))
            {
                groupedFiles[i++] = file;
            }
            return groupedFiles;
        }

        /// <summary>
        /// Retrieve folder with specified extension, or creates it if it does not exist
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="parentNode"></param>
        /// <returns></returns>
        private static PackedFolder _RetrieveExtensionFolder(string extension, PackedFolder parentNode)
        {
            PackedFolder pf = null;

            if (parentNode != null && parentNode.Children != null)
            {
                foreach (PackedFolder packedFolder in
                    parentNode.Children.Where(packedFolder => packedFolder.Name.Equals(extension,StringComparison.InvariantCultureIgnoreCase)))
                {
                    pf = packedFolder;
                    break;
                }

                if (pf == null)
                {
                    // Not found > it must be created
                    pf = new PackedFolder { Name = extension };
                    pf.FullPath = (parentNode.FullPath + "/" + pf.Name);
                    pf.Children = new List<PackedFolder>();
                }
            }
            return pf;
        }
      
        /// <summary>
        /// Returns checksum of given byte sequence
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        private static uint _ComputeChecksum(byte[] sequence)
        {
            crc32 crcObject = new crc32();
            long crc = ~crcObject.CRC(sequence);

            return (uint)crc;
        }

        /// <summary>
        /// Compute necessary padding size to respect specified block size
        /// </summary>
        /// <param name="index"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        private static int _ComputePaddingLength(int index, int blockSize)
        {
            int delta = index % blockSize;

            if ((index + delta) % blockSize != 0)
            {
                delta = blockSize - delta;
            }

            return delta;      
        }

        /// <summary>
        /// Returns a byte array of padding string of specified size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private static byte[] _GetPaddingString(int size)
        {
            byte[] pad = new byte[size];

            Encoding.ASCII.GetBytes(_PADDING_STRING, 0, size, pad, 0);

            return pad;
        }

        /// <summary>
        /// Utility method retrieving file type by extension.Uses the local cache.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        private uint _GetFileTypeFromExtension(string extension)
        {
            uint type = PackedFile.UNKNOWN_TYPE;

            extension = extension.ToUpper();

            if (_FileTypeByExtension.ContainsKey(extension))
            {
                type = _FileTypeByExtension[extension];
            }

            if (type == PackedFile.UNKNOWN_TYPE)
            {
                _Log.Warn("Unknown file type for extension " + extension);
            }

            return type;
        }

        /// <summary>
        /// Generic writes a section into provided binary writer
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="section"></param>
        /// <param name="blockSize">Block size to use (generates padding)</param>
        /// <returns></returns>
        private static void _WriteSection(BinaryWriter writer, Section section, uint blockSize)
        {
            // Length
            writer.Write(section.length);

            // Checksum
            writer.Write(section.checksum);

            // Data
            writer.Write(section.data);

            // Padding
            int paddingSize = _ComputePaddingLength((int)(section.address + _SECTION_HEADER_LENGTH + section.data.Length), (int) blockSize);
            writer.Write(_GetPaddingString(paddingSize));
        }

        /// <summary>
        /// Creates section with provided data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="address">section address in BNK file</param>
        /// <returns></returns>
        private static Section _CreateGenericSection(byte[] data, uint address)
        {
            Section s = (data == null
                             ? new Section
                            {
                                address = address
                            }
                             : new Section
                             {
                                 address = address,
                                 length = (uint)data.Length,
                                 checksum = _ComputeChecksum(data),
                                 data = data
                             }
                        );
            return s;
        }

        /// <summary>
        /// Reads section
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="sectionAddress"></param>
        /// <returns></returns>
        private static Section _ReadGenericSection(BinaryReader reader, uint sectionAddress)
        {
            // Sets read pointer
            reader.BaseStream.Seek(sectionAddress, SeekOrigin.Begin);

            // Creates section
            uint length = reader.ReadUInt32();
            uint readChecksum = reader.ReadUInt32();
            byte[] data = reader.ReadBytes((int)length);
            Section section = _CreateGenericSection(data, sectionAddress);

            // Verifies with checksum
            uint computedChecksum = _ComputeChecksum(section.data);
            _Log.Info("Read Bnk section @" + sectionAddress + ", checksum read=" + readChecksum + " VS computed=" +
                              computedChecksum);
            if (readChecksum != computedChecksum)
            {
                _Log.Warn("Checksum mismatch! see above");
            }

            return section;
        }
        #endregion

        #region Operations - Overrides of AbstractFile
        /// <summary>
        /// Reads / reloads contents of this file.
        /// </summary>
        public override void Read()
        {
            try
            {
                // Wipes indexes
                _FileTypeByExtension.Clear();
                _PackedFileByIdIndex.Clear();
                PackedRoot = null;

                using (BinaryReader reader = new BinaryReader(new FileStream(Name, FileMode.Open, FileAccess.Read)))
                {
                    _ReadHeaderSection(reader);

                    // Unk2 is optional and to be understood still
                if (_Unknown2SectionAddr != 0)
                {
                        _ReadUnknown2Section(reader);
                }

                    _ReadPackedData(reader);
                }
                }
            catch (Exception e)
                {
                throw new Exception("BNK read error, maybe uncompatible format", e);
                }
                }

        /// <summary>
        /// Saves current BNK file to disk
        /// </summary>
        public override void Save()
                {
            try
                {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
                {
                    _WriteSection(writer, _HeaderSection, _BlockSize1);
                    _WriteSection(writer, _SizeSection, _BlockSize1);

                    // Optional
                    if (_TypeMappingSectionAddr != 0)
                    {
                        _WriteSection(writer, _TypeMappingSection, _BlockSize1);
                    }

                    _WriteSection(writer, _TreeSection, _BlockSize1);
                    _WriteSection(writer, _OrderSection, _BlockSize2);

                    // Unk2 is optional
                    if (_Unknown2SectionAddr != 0)
                    {
                        _WriteSection(writer, _Unknown2Section, _BlockSize1);
                    }

                    // Packed files
                    _WritePackedFiles(writer);
                }
            }
            catch (Exception e)
            {
                throw new Exception("BNK write error", e);
            }
        }

        /// <summary>
        /// Dumps current object information to logs
        /// </summary>
        public override void Dump()
        {
            StringBuilder dumpInformation = new StringBuilder();

            dumpInformation.Append("*** Dump for: ");
            dumpInformation.Append(Name);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("Size=");
            dumpInformation.Append(_FileSize);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("Year=");
            dumpInformation.Append(_Year);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("Block Size 1=");
            dumpInformation.Append(_BlockSize1);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("Block Size 2=");
            dumpInformation.Append(_BlockSize2);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("Special Flag 1=");
            dumpInformation.Append(_SpecialFlag1);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("Special Flag 2=");
            dumpInformation.Append(_SpecialFlag2);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("Section addresses:");
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("- Address and Sizes=");
            dumpInformation.Append(_SizeSectionAddr);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("- Type Mapping=");
            dumpInformation.Append(_TypeMappingSectionAddr);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("- Tree=");
            dumpInformation.Append(_TreeSectionAddr);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("- Orders=");
            dumpInformation.Append(_OrderSectionAddr);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("- Unknown=");
            dumpInformation.Append(_Unknown2SectionAddr);
            dumpInformation.Append(Environment.NewLine); 
            dumpInformation.Append("- Data=");
            dumpInformation.Append(_DataSectionAddr);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("Packed files:");
            dumpInformation.Append(Environment.NewLine); 
            dumpInformation.Append("- Count=");
            dumpInformation.Append(_PackedCount);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("- Packed Size=");
            dumpInformation.Append(_PackedSize);
            dumpInformation.Append(Environment.NewLine);
            dumpInformation.Append("- Types=");
            dumpInformation.Append(Environment.NewLine);
            foreach (KeyValuePair<string, uint> extension in _FileTypeByExtension)
            {
                dumpInformation.Append(string.Format("Extension {0}->{1}", extension.Key, extension.Value));
                dumpInformation.Append(Environment.NewLine);
            }
            dumpInformation.Append("- Contents=");
            dumpInformation.Append(Environment.NewLine);
            // Following internal order in hierarchy
            foreach (KeyValuePair<uint, PackedFile> packedFile in _PackedFileByIdIndex.OrderBy(key => key.Key))
            {
                dumpInformation.Append(string.Format("({0}) {1}:{2} bytes - Magic={3} - Type={4}", packedFile.Key, packedFile.Value.FullPath, packedFile.Value.Size, packedFile.Value.Magic, packedFile.Value.Type));
                dumpInformation.Append(Environment.NewLine);
            }
            dumpInformation.Append("End of dump ***");

            DUMP_LOG.Info(dumpInformation);
        }
        #endregion
    }
}
