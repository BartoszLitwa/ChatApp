using System;
using System.Runtime.CompilerServices;

namespace ChatApp.Core
{
    /// <summary>
    /// Holds a bunch of loggers to log messages for the user
    /// </summary>
    public interface ILogFactory
    {
        #region Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        event Action<(string Message, LogLevel Level)> NewLog;

        #endregion

        #region Properties

        /// <summary>
        /// The level of logging to output
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the origin of where the log message was logged from
        /// suach as the class name, line number and file name
        /// </summary>
        bool IncludeLogOriginDetails { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specific logger to this factory
        /// </summary>
        /// <param name="logger"></param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Removes the specifed logger from this factory
        /// </summary>
        /// <param name="logger"></param>
        void RemoveLogger(ILogger logger);

        /// <summary>
        /// Logs the specific message to all loggers in this facotry
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message being loaded</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        void Log(string message, LogLevel level = LogLevel.Informative, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0);

        #endregion
    }
}
