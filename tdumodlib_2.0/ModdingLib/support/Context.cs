using System;
using System.IO;
using DjeLibrary_2.Systems.Windows.x64;
using Microsoft.Win32;


namespace ModdingLibrary_2.support
{
    /// <summary>
    /// Static library running context
    /// </summary>
    public static class Context
    {
        #region Enums
        /// <summary>
        /// Products
        /// </summary>
        public enum Product
        {
            TDU,
            TDU2,
            Unknown
        } ;

        /// <summary>
        /// Versions
        /// </summary>
        public enum Version
        {
            /// <summary>
            /// TDU2 default version
            /// </summary>
            Default,
            /// <summary>
            /// Genuine TDU
            /// </summary>
            MC_145A,
            /// <summary>
            /// TDU Patch 1
            /// </summary>
            MC_166A,
            /// <summary>
            // TDU with Megapack
            /// </summary>
            MC_166A_MP,
            /// <summary>
            // Community pack
            /// </summary>
            MC_CBP

        }

        #endregion

        #region Constants - Registry
        /// <summary>
        /// Registry key for TDU data (32bit OS)
        /// </summary>
        private const string _REGKEY_TDU_32 = @"SOFTWARE\Atari\TDU\";

        /// <summary>
        /// Registry key for TDU data (64bit OS)
        /// </summary>
        private const string _REGKEY_TDU_64 = @"SOFTWARE\Wow6432Node\Atari\TDU\";

        /// <summary>
        /// Registry value for TDU install location
        /// </summary>
        private const string _REGVALUE_TDU_INSTALL_PATH = @"install_path";

        /// <summary>
        /// Registry value for TDU install location
        /// </summary>
        private const string _REGVALUE_TDU_GAME_VERSION = @"Game_version";

        /// <summary>
        /// Registry data value for 1.45 TDU
        /// </summary>
        private const string _REGDATA_1_45_VERSION = @"VMC1.45A_MC1.2";

        /// <summary>
        /// Registry data value for 1.66 TDU
        /// </summary>
        private const string _REGDATA_1_66_VERSION = @"Patch 1.66A";

        /// <summary>
        /// Registry data value for 1.66 TDU + megapack
        /// </summary>
        private const string _REGDATA_1_66_MEGAPACK_VERSION = @"Patch 1.66A + Bonus Pack";
        #endregion

        #region Properties
        /// <summary>
        /// Current game
        /// </summary>
        public static Product GameProduct { get; set; }

        /// <summary>
        /// Game version
        /// </summary>
        public static Version GameVersion { get; set; }

        /// <summary>
        /// Full path of game install folder
        /// </summary>
        public static string GameFolder { get; set; }
        #endregion

        /// <summary>
        /// Static constructor
        /// </summary>
        static Context() 
        {
            try
            {
                GameFolder = _RetrieveFolder();
                GameProduct = _RetrieveProduct();
                GameVersion = _RetrieveVersion();
            }
            catch
            {
                // Default values: TDU2 - default
                GameProduct = (GameProduct == Product.Unknown ? Product.TDU2 : GameProduct);
                GameVersion = Version.Default;
            }
        }

        #region Private methods
        /// <summary>
        /// Seeks for game install path
        /// </summary>
        /// <returns></returns>
        private static string _RetrieveFolder()
        {
            string installPath;

            try
            {
                RegistryKey key = Registry.LocalMachine;
                string keyName = (System64.X64OperatingSystem ?
                               _REGKEY_TDU_64
                               : _REGKEY_TDU_32);

                key = key.OpenSubKey(keyName);

                if (key == null)
                {
                    throw new Exception("TDU registry key not found under LOCAL_MACHINE: " + keyName);
                }

                installPath = key.GetValue(_REGVALUE_TDU_INSTALL_PATH) as string;
            }
            catch (Exception ex)
            {
                // TODO log
                throw ex;
            }

            return installPath ?? "";
        }

        /// <summary>
        /// Seeks for TDU1 or TDU2. game folder must be known.
        /// </summary>
        /// <returns></returns>
        private static Product _RetrieveProduct()
        {
            Product product = Product.Unknown;

            if(GameFolder != null && Directory.Exists(GameFolder))
            {
                if (File.Exists(GameFolder + @"\TestDriveUnlimited.exe"))
                {
                    product = Product.TDU;
                }
                else if (File.Exists(GameFolder + @"\TestDriveUnlimited2.exe"))
                {
                    product = Product.TDU2;
                }        
            }
            return product;
        }

        /// <summary>
        /// Seeks for game version. game product must be known
        /// </summary>
        /// <returns></returns>
        private static Version _RetrieveVersion()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
