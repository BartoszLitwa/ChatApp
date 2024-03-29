﻿using static ChatApp.DI;

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
        public ApplicationViewModel ApplicationViewModel => ViewModelApplication;

        /// <summary>
        /// The application view model
        /// </summary>
        public SettingsViewModel SettingsViewModel => ViewModelSettings;


        #endregion
    }
}
