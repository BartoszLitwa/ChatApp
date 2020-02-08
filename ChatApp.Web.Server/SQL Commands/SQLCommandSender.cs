using ChatApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChatApp.Web.Server
{
    public static class SQLCommandSender
    {
        #region Public Methods

        /// <summary>
        /// Creates the table using the given sql Table Type
        /// </summary>
        /// <typeparam name="T">Type of the api model to pass to create the table</typeparam>
        /// <param name="mContext"></param>
        /// <param name="apiModel">Type of the api model to pass to create the table</param>
        /// <param name="type">Type of SQL Table to create</param>
        /// <returns></returns>
        [System.Obsolete]
        public static async Task<int> CreateTableAsync<T>(this ApplicationDBContext mContext, T apiModel, SQLTableTypeEnum type)
        {
            var sqlQuery = "";

            // Switch betweens sql tabel types
            switch (type)
            {
                case SQLTableTypeEnum.MessageHistory:
                    sqlQuery = CreateTableMessageHistoryAsync(apiModel as TableApiModel, type);
                    break;
                case SQLTableTypeEnum.FriendList:
                    sqlQuery = CreateTableFriendListAsync(apiModel as TableApiModel, type);
                    break;
                case SQLTableTypeEnum.ProfileSettings:
                    sqlQuery = CreateTableProfileSettingsAsync(apiModel as TableApiModel, type);
                    break;
                default:
                    Debugger.Break();
                    break;
            }

            return await mContext.Database.ExecuteSqlCommandAsync(sqlQuery);
        }

        /// <summary>
        /// Inserts into the table using the given sql Table Type
        /// </summary>
        /// <typeparam name="T">Type of the api model to pass to insert into the table</typeparam>
        /// <param name="mContext"></param>
        /// <param name="apiModel">Type of the api model to pass to create the table</param>
        /// <param name="type">Type of SQL Table to create</param>
        /// <returns></returns>
        [System.Obsolete]
        public static async Task<int> InsertIntoTableAsync<T>(this ApplicationDBContext mContext, T apiModel, SQLTableTypeEnum type)
        {
            var sqlQuery = "";

            // Switch betweens sql tabel types
            switch (type)
            {
                case SQLTableTypeEnum.MessageHistory:
                    sqlQuery = InsertIntoMessageHistoryAsync(apiModel as MessageApiModel, type);
                    break;
                case SQLTableTypeEnum.FriendList:
                    sqlQuery = InsertIntoFriendListAsync(apiModel as FriendApiModel, type);
                    break;
                case SQLTableTypeEnum.ProfileSettings:
                    sqlQuery = InsertIntoProfileSettingsAsync(apiModel as ProfileSettingsApiModel, type);
                    break;
                default:
                    Debugger.Break();
                    break;
            }

            return await mContext.Database.ExecuteSqlCommandAsync(sqlQuery);
        }

        #endregion

        #region Private Helpers

        #region Create Table Methods

        [System.Obsolete]
        public static string CreateTableMessageHistoryAsync(TableApiModel apiModel, SQLTableTypeEnum type)
        {
            // Sort the names of users by alphabet
            var users = new string[] { apiModel.Username, apiModel.SecondUser }.SortByOrder();

            // Create the name of the table
            var tableName = $"{ SQLTableTypeHelpers.SQLTableTypeToString(type) }_{ users[0] }_{ users[1] }";

            // SQL Query for server to create the table
            return $"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')" +
                $" CREATE TABLE {tableName}" +
                SQLCreateTableCommandsHelpers.SQLTableQueriesToString(type);
        }

        [System.Obsolete]
        public static string CreateTableFriendListAsync(TableApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the name of the table
            var tableName = $"{SQLTableTypeHelpers.SQLTableTypeToString(type)}_{apiModel.Username}";

            // SQL Query for server to create the table
            return $"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')" +
                $" CREATE TABLE {tableName}" +
                SQLCreateTableCommandsHelpers.SQLTableQueriesToString(type);
        }

        [System.Obsolete]
        public static string CreateTableProfileSettingsAsync(TableApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the name of the table
            var tableName = $"{SQLTableTypeHelpers.SQLTableTypeToString(type)}_{apiModel.Username}";

            // SQL Query for server to create the table
            return $"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')" +
                $" CREATE TABLE {tableName}" +
                SQLCreateTableCommandsHelpers.SQLTableQueriesToString(type);
        }

        #endregion

        #region Insert Into Table

        [System.Obsolete]
        public static string InsertIntoMessageHistoryAsync(MessageApiModel apiModel, SQLTableTypeEnum type)
        {
            // Sort the names of users by alphabet
            var users = new string[] { apiModel.SendBy, apiModel.SendTo }.SortByOrder();

            // Create the name of the table
            var tableName = $"{ SQLTableTypeHelpers.SQLTableTypeToString(type) }_{ users[0] }_{ users[1] }";

            // SQL Query for server to create the table
            return $" INSERT INTO {tableName} " +
                    SQLInsertIntoTableCommandsHelpers.SQLTableQueriesToString(type) +
                    // SendBy, Message, MessageSentTime, MessageReadTime, ImageAttachment, ImageAttachmentURL
                    $" '{apiModel.SendBy}', '{apiModel.Message}', '{apiModel.MessageSentTime}', '{apiModel.MessageReadTime}', '{apiModel.ImageAttachment}', '{apiModel.ImageAttachmentURL}' );";
        }

        [System.Obsolete]
        public static string InsertIntoFriendListAsync(FriendApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the name of the table
            var tableName = $"{ SQLTableTypeHelpers.SQLTableTypeToString(type) }_{ apiModel.Username }_";

            // SQL Query for server to create the table
            return $" INSERT INTO {tableName} " +
                    SQLInsertIntoTableCommandsHelpers.SQLTableQueriesToString(type) +
                    /// Username, AddTime, Accepted, AcceptationAddTime
                    $" '{apiModel.Username}', '{apiModel.AddTime}', '{apiModel.Accepted}', '{apiModel.AcceptationAddTime}' );";
        }

        [System.Obsolete]
        public static string InsertIntoProfileSettingsAsync(ProfileSettingsApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the name of the table
            var tableName = $"{ SQLTableTypeHelpers.SQLTableTypeToString(type) }_{ apiModel.Username }";

            // SQL Query for server to Update the Profile Settings
            return $" UPDATE {tableName} SET" +
                    /// LastLoggedIn, FirstLoggedIn, CurrentStatus, CurrentTheme
                    $" LastLoggedIn = '{apiModel.LastLoggedIn}', FirstLoggedIn = '{apiModel.FirstLoggedIn}', CurrentStatus = '{apiModel.CurrentStatus}', CurrentTheme = '{apiModel.Theme}' )" +
                    $" WHERE ID = 0;";
        }

        #endregion

        #region Get From the Table

        [System.Obsolete]
        public static async Task<ChatMessagesApiModel> GetMessagesFromChatAsync(this ApplicationDBContext mContext, TableApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the api model to return
            var Messages = new ChatMessagesApiModel();

            using (var con = new SqlConnection(IoCContainer.Configuration.GetConnectionString("DefaultConnection")))
            {
                // Open the connection
                con.Open();

                try
                {
                    // Sort the names of users by alphabet
                    var users = new string[] { apiModel.Username, apiModel.SecondUser }.SortByOrder();

                    // Create the name of the table
                    var tableName = $"{ SQLTableTypeHelpers.SQLTableTypeToString(type) }_{ users[0] }_{ users[1] }";

                    var query = $"SELECT {SQLSelectFromTableCommandsHelpers.SQLTableQueriesToString(type)} FROM {tableName}";

                    using (var sqlCommand = new SqlCommand(query, con))
                    {
                        var reader = sqlCommand.ExecuteReader();

                        while (await reader.ReadAsync())
                        {
                            // Add the message to the list
                            Messages.ChatMessages.Add(new MessageApiModel
                            {
                                ID = reader.GetInt32(0),
                                SendBy = reader.GetString(1),
                                Message = reader.GetString(2),
                                MessageSentTime = reader.GetDateTimeOffset(3),
                                MessageReadTime = reader.GetDateTimeOffset(4),
                                ImageAttachment = reader.GetBoolean(5),
                                ImageAttachmentURL = reader.GetString(6),
                            });
                        }
                    }
                }
#pragma warning disable CS0168 // For Developer to know what happend
                catch (Exception ex)
#pragma warning restore CS0168 //
                {
                    // Break while debugging to get the error
                    Debugger.Break();
                }

                // Return the list of messages
                return Messages;
            }
        }

        #endregion

        #endregion
    }
}
