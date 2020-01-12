using System;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    /// <summary>
    /// Logs yo a specific file
    /// </summary>
    public class FileLogger : ILogger
    {
        #region Public properties

        /// <summary>
        /// The path to write the log file to
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// If true, logs the current time with each message
        /// </summary>
        public bool LogTime { get; set; } = true;

        #endregion

        #region Constrcutor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="filePath">The path to log to</param>
        public FileLogger(string filePath, bool logTime = true)
        {
            // Set the file path property
            FilePath = filePath;

            // Set the log time property
            LogTime = logTime;
        }

        #endregion

        #region Logger Methods

        public void Log(string message, LogLevel level)
        {
            // Get current time
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Prepend the time if desired
            var timeLogString = LogTime ? $"[{currentTime}]" : "";

            // Write message to the file
            CoreDI.FileManager.WriteTextToFileAsync($"{timeLogString} {message}{Environment.NewLine}", FilePath, append: true);
        }

        #endregion
    }
}
