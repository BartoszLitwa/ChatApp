using Dna;

namespace ChatApp.Core
{
    /// <summary>
    /// The IoC conatiner for our application
    /// </summary>
    public static class CoreDI
    {
        /// <summary>
        /// A shortcut to accces the <see cref="IFileManager"/>
        /// </summary>
        public static IFileManager FileManager => Framework.Service<IFileManager>();

        /// <summary>
        /// A shortcut to accces the <see cref="ITaskManager"/>
        /// </summary>
        public static ITaskManager TaskManager => Framework.Service<ITaskManager>();
    }
}
