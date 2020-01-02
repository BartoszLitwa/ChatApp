namespace ChatApp.Core
{
    /// <summary>
    /// The level of details to output for a logger
    /// </summary>
    public enum LogOutputLevel
    {
        /// <summary>
        /// Logs Everything
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Lots of information except debug information
        /// </summary>
        Verbose = 2,

        /// <summary>
        /// Logs all informative messages, ignoring any debug and verbose messages
        /// </summary>
        Informative = 3,

        /// <summary>
        /// Log only critical erros and warnings and successes, but no generla information
        /// </summary>
        Critcal = 4,

        /// <summary>
        /// The logger will never output anything
        /// </summary>
        Nothing = 10,
    }
}
