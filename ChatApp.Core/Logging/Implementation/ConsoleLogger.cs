using System;

namespace ChatApp.Core
{
    /// <summary>
    /// Logs the messages to the Console
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        #region Constrcutor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConsoleLogger()
        {
            Console.
        }

        #endregion

        /// <summary>
        /// Logs the given message to the system Console
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="level">The level of the message</param>
        public void Log(string message, LogLevel level)
        {
            // Save old color
            var OldConsoleColor = ConsoleColor.White;
            var category = string.Empty;

            switch (level)
            {
                    // Debug is Blue
                case LogLevel.Debug:
                    OldConsoleColor = ConsoleColor.Blue;
                    category = "Information";
                    break;

                    // Verbose is Gray
                case LogLevel.Verbose:
                    OldConsoleColor = ConsoleColor.Gray;
                    category = "Verbose";
                    break;

                case LogLevel.Informative:
                    OldConsoleColor = ConsoleColor.Yellow;
                    category = "Informative";
                    break;

                    // Warning is dark Yellow
                case LogLevel.Warning:
                    OldConsoleColor = ConsoleColor.DarkYellow;
                    category = "Warning";
                    break;

                    // Error is red
                case LogLevel.Error:
                    OldConsoleColor = ConsoleColor.Red;
                    category = "Error";
                    break;

                    // Succes is green
                case LogLevel.Success:
                    OldConsoleColor = ConsoleColor.Green;
                    category = "------";
                    break;
            }

            // Set the new conosle color
            Console.ForegroundColor = OldConsoleColor;

            // Write message to console
            Console.WriteLine($"[{level}]".ToString().PadRight(13, ' ') + message);

            // Reset console color
            Console.ForegroundColor = OldConsoleColor;
        }
    }
}
