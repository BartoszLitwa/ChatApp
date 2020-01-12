using ChatApp.Core;
using static ChatApp.DI;

namespace ChatApp
{
    /// <summary>
    /// Locates vie models from IoC for use in binding in Xaml files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => ViewModelApplication;

        /// <summary>
        /// The application view model
        /// </summary>
        public static SettingsViewModel SettingsViewModel => ViewModelSettings;


        #endregion
    }
}
