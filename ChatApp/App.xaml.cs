using ChatApp.Core;
using ChatApp.Relational;
using Dna;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;

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
        protected override async void OnStartup(StartupEventArgs e)
        {
            //Let the base application do what it needs
            base.OnStartup(e);

            // Setup the main application
            await ApplicationSetupAsync();

            // Log it
            IoC.Logger.Log("Application starting", LogLevel.Debug);

            // Setup the application view model based on if we are logged in
            IoC.Application.GoToPage(
                // If we are logged in...
                await IoC.ClientDataStore.HasCredentialsAsync() ?
                // Go to chat page
                ApplicationPage.Chat :
                // Otherwise, go to login page
                ApplicationPage.Login);

            //Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private async Task ApplicationSetupAsync()
        {
            // Setup the Dna Framework
            Framework.Construct<DefaultFrameworkConstruction>()
                .AddFileLogger("DNAlog.txt")
                .UseClientDataStore()
                .Build();

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

            // Ensure the client data store 
            await IoC.ClientDataStore.EnsureDataStoreAsync();

            // Load new settings
            await IoC.Settings.LoadAsync();
        }
    }
}
