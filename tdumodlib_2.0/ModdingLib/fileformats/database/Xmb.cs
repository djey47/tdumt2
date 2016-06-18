using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DjeLibrary_2.Systems;
using log4net;
using ModdingLibrary_2.fileformats.banks;

namespace ModdingLibrary_2.fileformats.database
{
    public class Xmb : AbstractFile
    {
        #region Structures
        public struct VolumeEntry
        {
            public string sampleName;
            public uint inAddress;
            public uint outAddress;
            public float inVolume;
            public float outVolume;
        }
        #endregion

        #region Technical members
        /// <summary>
        /// Internal logger
        /// </summary>
        private static readonly ILog _Log = LogManager.GetLogger(typeof(Xmb));
        #endregion

        #region Private data
        private byte[] _Data;
        #endregion

        #region Public methods
        /// <summary>
        /// Returns a volume entry corresponding to given sample name.
        /// </summary>
        /// <param name="sampleName"></param>
        /// <returns></returns>
        /// <exception cref="Exception">When sample does not exist</exception>
        public VolumeEntry GetVolumeForSample(string sampleName)
        {
            // Converts string into Array
            byte[] searchedArray = new byte[sampleName.Length + 2];
            byte[] sampleNameArray = System.Text.Encoding.ASCII.GetBytes(sampleName);

            // Zone starts with  '80,3F'
            searchedArray[0] = 0x80;
            searchedArray[1] = 0x3F;
            Array.Copy(sampleNameArray, 0, searchedArray, 2, sampleNameArray.Length);

            // Begins search
            int zoneIndex = _SubArray(_Data, searchedArray);
            if (zoneIndex == -1)
            {
                string msgFormat = "Sound sample '{0}' not found!";
                throw new Exception(string.Format(msgFormat, sampleName));
            }

            // Retrieves values in data bytes
            VolumeEntry entry = new VolumeEntry();
            entry.sampleName = sampleName;

            zoneIndex += 2;
            using(BinaryReader reader = new BinaryReader(new MemoryStream(_Data)))
            {
                // IN volume : name address - 24 bytes
                uint inAddress = (uint)zoneIndex - 24;
                reader.BaseStream.Seek(inAddress, SeekOrigin.Begin);
                float inVolume = reader.ReadSingle();
                entry.inAddress = inAddress;
                entry.inVolume = inVolume;

                // OUT volume : name address - 20 bytes
                uint outAddress = (uint)zoneIndex - 20;
                reader.BaseStream.Seek(outAddress, SeekOrigin.Begin);
                float outVolume = reader.ReadSingle();
                entry.outAddress = outAddress;
                entry.outVolume = outVolume;
            };

            return entry;
        }

        /// <summary>
        /// Updates data for given entry
        /// </summary>
        /// <param name="entry"></param>
        public void SetVolumeForSample(VolumeEntry entry)
        {
            using (BinaryWriter writer = new BinaryWriter(new MemoryStream(_Data)))
            {
                // IN volume : name address - 24 bytes
                writer.BaseStream.Seek(entry.inAddress, SeekOrigin.Begin);
                writer.Write(entry.inVolume);

                // OUT volume : name address - 20 bytes
                writer.BaseStream.Seek(entry.outAddress, SeekOrigin.Begin);
                writer.Write(entry.outVolume);
            };
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Returns index of first occurrence of part array in whole array
        /// </summary>
        /// <param name="whole"></param>
        /// <param name="part"></param>
        /// <returns></returns>
        private int _SubArray(byte[] whole, byte[] part)
        {
            return (from index in Enumerable.Range(0, 1 + whole.Length - part.Length)
                    where whole.Skip(index).Take(part.Length).SequenceEqual(part)
                    select (int?)index).FirstOrDefault().GetValueOrDefault(-1);
        }
        #endregion

        #region Overrides of AbstractFile
        /// <summary>
        /// Reads current file and stores information into memory
        /// </summary>
        public override void Read()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(new FileStream(Name, FileMode.Open, FileAccess.Read)))
                {
                    FileInfo fi = new FileInfo(Name);
                    _Data = reader.ReadBytes(checked((int)fi.Length));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Xmb read error.", e);
            }
        }

        /// <summary>
        /// Save current file to disk
        /// </summary>
        public override void Save()
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(new FileStream(Name, FileMode.Create, FileAccess.Write)))
                {
                    writer.Write(_Data);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Xmb write error.", e);
            }
        }

        /// <summary>
        /// Dumps current object information to logs
        /// </summary>
        public override void Dump()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
