using Microsoft.Win32;

namespace DjeLibrary_2.Systems.Windows.x64
{
    /// <summary>
    /// Static class giving access to advanced system features (64bit).
    /// </summary>
    public static class System64
    {
        #region Registry constants
        /// <summary>
        /// Registry key: for 32bit software running under x64
        /// </summary>
        private const string _REGKEY_SOFTWARE_WOW = @"SOFTWARE\Wow6432Node";
        #endregion

        #region Properties
        /// <summary>
        /// Returns true if current OS is a 64bit one
        /// </summary>
        /// <returns></returns>
        public static bool X64OperatingSystem
        {
            get
            {
                RegistryKey key = Registry.LocalMachine;

                return (key.OpenSubKey(_REGKEY_SOFTWARE_WOW) != null);
            }
        }
        #endregion
    }
}