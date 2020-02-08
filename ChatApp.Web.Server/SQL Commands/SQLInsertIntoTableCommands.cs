using ChatApp.Core;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Class that contains all SQL Queries for creating the tables
    /// </summary>
    public static class SQLInsertIntoTableCommands
    {
        /// <summary>
        /// SQL Query for getting info from the Message History table
        /// SendBy, Message, MessageSentTime, MessageReadTime, ImageAttachment, ImageAttachmentURL
        /// </summary>
        public const string MessageHistory = " ( SendBy, " +
                                             " Message, " +
                                             " MessageSentTime, " +
                                             " MessageReadTime, " +
                                             " ImageAttachment, " +
                                             " ImageAttachmentURL ) VALUES (";

        /// <summary>
        /// SQL Query for getting info from the Friend List table
        /// Username, AddTime, Accepted, AcceptationAddTime
        /// </summary>
        public const string FriendList = " ( Username ," +
                                         " AddTime ," +
                                         " Accepted , " +
                                         " AcceptationAddTime ) VALUES (";

        /// <summary>
        /// SQL Query for getting info from the Profile and Settings table
        /// LastLoggedIn, FirstLoggedIn, CurrentStatus, CurrentTheme
        /// </summary>
        public const string ProfileSettings = " ( LastLoggedIn ," +
                                              " FirstLoggedIn ," +
                                              " CurrentStatus ," +
                                              " CurrentTheme ) VALUES (";
    }

    /// <summary>
    /// Helpers for <see cref="SQLInsertIntoTableCommands"/>
    /// </summary>
    public static class SQLInsertIntoTableCommandsHelpers
    {
        /// <summary>
        /// Takes the <see cref="SQLTableTypeEnum"/> and returns the sql query for inserting into table
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string SQLTableQueriesToString(SQLTableTypeEnum type)
        {
            switch (type)
            {
                case SQLTableTypeEnum.MessageHistory:
                    return SQLInsertIntoTableCommands.MessageHistory;
                case SQLTableTypeEnum.FriendList:
                    return SQLInsertIntoTableCommands.FriendList;
                case SQLTableTypeEnum.ProfileSettings:
                    return SQLInsertIntoTableCommands.ProfileSettings;
                default:
                    return "";
            }
        }
    }
}
