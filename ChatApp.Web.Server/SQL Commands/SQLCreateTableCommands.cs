using ChatApp.Core;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Class that contains all SQL Queries for creating the tables
    /// </summary>
    public static class SQLCreateTableCommands
    {
        /// <summary>
        /// SQL Query for creating the Message History table
        /// </summary>
        public const string MessageHistory = " ( ID INT PRIMARY KEY IDENTITY(0,1) ," +
                                             " SendBy varchar(100) NOT NULL," +
                                             " Message varchar(2000) NOT NULL," +
                                             " MessageSentTime DATETIME NOT NULL," +
                                             " MessageReadTime DATETIME, " +
                                             " ImageAttachment BIT NOT NULL, " +
                                             " ImageAttachmentURL varchar(200) );";

        /// <summary>
        /// SQL Query for creating the Friend List table
        /// </summary>
        public const string FriendList = " ( ID INT PRIMARY KEY IDENTITY(0,1) ," +
                                         " Username varchar(100) NOT NULL," +
                                         " AddTime DATETIME NOT NULL," +
                                         " Accepted BIT NOT NULL, " +
                                         " AcceptaionAddTime DATETIME );";

        /// <summary>
        /// SQL Query for creating the Profile and Settings table
        /// </summary>
        public const string ProfileSettings = " ( ID INT PRIMARY KEY IDENTITY(0,1) ," +
                                              " SendBy varchar(100) NOT NULL," +
                                              " Message varchar(2000) NOT NULL," +
                                              " MessageSentTime DATETIME NOT NULL," +
                                              " MessageReadTime DATETIME NOT NULL, " +
                                              " ImageAttachment BIT NOT NULL, " +
                                              " ImageAttachmentURL varchar(200) );";
    }

    /// <summary>
    /// Helpers for <see cref="SQLCreateTableCommands"/>
    /// </summary>
    public static class SQLCreateTableCommandsHelpers
    {
        /// <summary>
        /// Takes the <see cref="SQLTableTypeEnum"/> type and returns the sql query for creating this table
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string SQLTableQueriesToString(SQLTableTypeEnum type)
        {
            switch (type)
            {
                case SQLTableTypeEnum.MessageHistory:
                    return SQLCreateTableCommands.MessageHistory;
                case SQLTableTypeEnum.FriendList:
                    return SQLCreateTableCommands.FriendList;
                case SQLTableTypeEnum.ProfileSettings:
                    return SQLCreateTableCommands.ProfileSettings;
                default:
                    return "";
            }
        }
    }
}
