﻿using Ninject;
using System;

namespace ChatApp.Core
{
    /// <summary>
    /// The IoC conatiner for our application
    /// </summary>
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// The kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// A shortcut to accces the <see cref="IUIManager"/>
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// A shortcut to accces the <see cref="IUIManager"/>
        /// </summary>
        public static ILogFactory Logger => IoC.Get<ILogFactory>();

        /// <summary>
        /// A shortcut to accces the <see cref="IFileManager"/>
        /// </summary>
        public static IFileManager File => IoC.Get<IFileManager>();

        /// <summary>
        /// A shortcut to accces the <see cref="ITaskManager"/>
        /// </summary>
        public static ITaskManager Task => IoC.Get<ITaskManager>();

        /// <summary>
        /// A shortcut to accces the <see cref="ApplicationViewModel"/>
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// A shortcut to accces the <see cref="SettingsViewModel"/>
        /// </summary>
        public static SettingsViewModel Settings => IoC.Get<SettingsViewModel>();

        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC conatiner, binds all information required and is ready for use
        /// NOTE: Must be called as soon as your application starts up to ensure all
        ///       Services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();
        }


        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to a singleton instance of Application view model
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());

            // Bind to a singleton instance of Settings view model
            Kernel.Bind<SettingsViewModel>().ToConstant(new SettingsViewModel());
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Get's a service from the IoC of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

        #endregion
    }
}
