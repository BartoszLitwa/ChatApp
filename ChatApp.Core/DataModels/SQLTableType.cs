namespace ChatApp.Core
{
    /// <summary>
    /// Type of sql tables needed to create
    /// </summary>
    public class SQLTableType
    {
        #region Public Properties

        /// <summary>
        /// Create the table for Message History of chat
        /// </summary>
        public const string MessageHistory = "dbo.MessageHistory";

        /// <summary>
        /// Create the table for Message History of chat
        /// </summary>
        public const string FriendList = "dbo.FriendList";

        /// <summary>
        /// Create the table for Profile details and settings for this user
        /// </summary>
        public const string ProfileSettings = "dbo.ProfileSettings";

        #endregion
    }

    public enum SQLTableTypeEnum
    {
        #region Public Properties

        /// <summary>
        /// Create the table for Message History of chat
        /// </summary>
        MessageHistory = 0,

        /// <summary>
        /// Create the table for Message History of chat
        /// </summary>
        FriendList = 1,

        /// <summary>
        /// Create the table for Profile details and settings for this user
        /// </summary>
        ProfileSettings = 2,

        #endregion
    }

    /// <summary>
    /// Class with helpers for the <see cref="SQLTableType"/> and <see cref="SQLTableTypeEnum"/>
    /// </summary>
    public static class SQLTableTypeHelpers
    {
        /// <summary>
        /// Takes the Sql Table type and returns the string for sql table name
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string SQLTableTypeToString(SQLTableTypeEnum type)
        {
            switch (type)
            {
                case SQLTableTypeEnum.MessageHistory:
                    return SQLTableType.MessageHistory;
                case SQLTableTypeEnum.FriendList:
                    return SQLTableType.FriendList;
                case SQLTableTypeEnum.ProfileSettings:
                    return SQLTableType.ProfileSettings;
                default:
                    return "";
            }
        }
    }
}
