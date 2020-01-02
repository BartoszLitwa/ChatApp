using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ChatApp.Core
{
    /// <summary>
    /// The standard log factory for ChatApp
    /// Logs details to the Console by default
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Methods

        /// <summary>
        /// The list of loggers in this factory
        /// </summary>
        protected List<ILogger> mLoggers = new List<ILogger>();

        /// <summary>
        /// A lock for the logger list to keep it safe
        /// </summary>
        protected object mLoggersLock = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// The level of logging to output
        /// </summary>
        public LogOutputLevel LogOutputLevel { get; set; } = LogOutputLevel.Debug;

        /// <summary>
        /// If true, includes the origin of where the log message was logged from
        /// suach as the class name, line number and file name
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion 

        #region Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        #endregion

        #region Constrcutor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="loggers">The loggers to add to the factory, on top of the stack loggers already included</param>
        public BaseLogFactory(ILogger[] loggers = null)
        {
            // Add console logger
            AddLogger(new ConsoleLogger());

            // Add any others passed in
            if (loggers != null)
                foreach (var log in loggers)
                    AddLogger(log);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the specific logger to this factory
        /// </summary>
        /// <param name="logger"></param>
        public void AddLogger(ILogger logger)
        {
            // Log the list so it is thread-safe
            lock (mLoggersLock)
            {
                // If the logger is not already in the list
                if (!mLoggers.Contains(logger))
                    // Add the logger to teh list
                    mLoggers.Add(logger);
            }
        }

        /// <summary>
        /// Removes the specifed logger from this factory
        /// </summary>
        /// <param name="logger"></param>
        public void RemoveLogger(ILogger logger)
        {
            // Log the list so it is thread-safe
            lock (mLoggersLock)
            {
                // If the logger is in the list
                if (mLoggers.Contains(logger))
                    // Remove the logger from the list
                    mLoggers.Remove(logger);
            }
        }

        /// <summary>
        /// Logs the specific message to all loggers in this facotry
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message being loaded</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filePath">The code filneame that his message was logged from</param>
        /// <param name="lineNumber">The line of code in the filnemae this message was logged from</param>
        public void Log(string message, LogLevel level = LogLevel.Informative, [CallerMemberName] string origin = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            // If we should not log the message as the level is too low
            if ((int)level < (int)LogOutputLevel)
                return;

            // If the user wants to know where the log originated from
            if (IncludeLogOriginDetails)
                message = $"[{Path.GetFileName(filePath)} > {origin} > Line {lineNumber}] {Environment.NewLine} {message}";

            // Log to all logger
            mLoggers.ForEach(logger => logger.Log(message, level));

            // Inform listeners
            NewLog.Invoke((message, level));
        }

        #endregion
    }
}
