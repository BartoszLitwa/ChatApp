using ChatApp.Core;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Class that contains all SQL Queries for creating the tables
    /// </summary>
    public static class SQLSelectFromTableCommands
    {
        /// <summary>
        /// SQL Query for getting info from the Message History table
        /// </summary>
        public const string MessageHistory = "([ID], " +
                                             " [SendBy], " +
                                             " [Message], " +
                                             " [MessageSentTime], " +
                                             " [MessageReadTime], " +
                                             " [ImageAttachment], " +
                                             " [ImageAttachmentURL] )";

        /// <summary>
        /// SQL Query for getting info from the Friend List table
        /// </summary>
        public const string FriendList = "([Username]," +
                                         " [AddTime DATETIME NOT NULL," +
                                         " [Accepted BIT NOT NULL, " +
                                         " [AcceptationAddTime DATETIME )";

        /// <summary>
        /// SQL Query for getting info from the Profile and Settings table
        /// </summary>
        public const string ProfileSettings = "([LastLoggedIn] ," +
                                              " [FirstLoggedIn] ," +
                                              " [CurrentStatus] ," +
                                              " [CurrentTheme] )";
    }

    /// <summary>
    /// Helpers for <see cref="SQLSelectFromTableCommands"/>
    /// </summary>
    public static class SQLSelectFromTableCommandsHelpers
    {
        /// <summary>
        /// Takes the <see cref="SQLTableTypeEnum"/> and returns the sql query for selecting from the table
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string SQLTableQueriesToString(SQLTableTypeEnum type)
        {
            switch (type)
            {
                case SQLTableTypeEnum.MessageHistory:
                    return SQLSelectFromTableCommands.MessageHistory;
                case SQLTableTypeEnum.FriendList:
                    return SQLSelectFromTableCommands.FriendList;
                case SQLTableTypeEnum.ProfileSettings:
                    return SQLSelectFromTableCommands.ProfileSettings;
                default:
                    return "";
            }
        }
    }
}
