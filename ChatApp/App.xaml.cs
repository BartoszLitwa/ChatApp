﻿using ChatApp.Core;
using Dna;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load our IoC immediatly before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            //Let the base application do what it needs
            base.OnStartup(e);

            // Setup the main application
            ApplicationSetup();

            // Log it
            IoC.Logger.Log("Application starting", LogLevel.Debug);

            //Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private void ApplicationSetup()
        {
            new DefaultFrameworkConstruction().Build();

            // Setup IoC
            IoC.Setup();

            // Bind a logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
            { 
                // TODO: Add ApplicationSetings so we can set/edit a log location
                // For now just log to the path where this application is
                new Core.FileLogger("log.txt"),
            }));

            // Bind a Task Manager
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            // Bind a File Manager
            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            // Bind a UI manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

        }
    }
}
