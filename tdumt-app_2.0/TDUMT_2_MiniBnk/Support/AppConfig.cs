using DjeLibrary_2.Support.Settings;

namespace TDUMT_2.MiniBnkManager.Support
{
    /// <summary>
    /// MBM2 configuration
    /// </summary>
    public class AppConfig : CustomSettingsBase
    {
        private static AppConfig _instance;

        /// <summary>
        /// Singleton accessor
        /// </summary>
        public static AppConfig Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppConfig();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Directory where to extract/repack BNK files
        /// </summary>
        public string WorkDirectory
        {
            get => _GetParameter("WorkDirectory") as string;
            set => _SetParameter("WorkDirectory", value);
        }
    }
}