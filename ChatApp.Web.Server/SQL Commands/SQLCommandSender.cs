using ChatApp.Core;
using Microsoft.EntityFrameworkCore;
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
                    sqlQuery = CreateTableMessageHistoryAsync(apiModel as CreateTableApiModel, type);
                    break;
                case SQLTableTypeEnum.FriendList:
                    sqlQuery = CreateTableFriendListAsync(apiModel as CreateTableApiModel, type);
                    break;
                case SQLTableTypeEnum.ProfileSettings:
                    sqlQuery = CreateTableProfileSettingsAsync(apiModel as CreateTableApiModel, type);
                    break;
                default:
                    Debugger.Break();
                    break;
            }

            return await mContext.Database.ExecuteSqlCommandAsync(sqlQuery);
        }

        [System.Obsolete]
        public static async Task<int> SendMessageToTableAsync(this ApplicationDBContext mContext, MessageApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the name of the table
            var tableName = $"{SQLTableTypeHelpers.SQLTableTypeToString(type)}_{apiModel.SendBy}_{apiModel.SendTo}";

            var sqlQuery = $"IF EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')" +
                $" INSERT INTO {tableName}" +
                $" ( SendBy, Message, MessageSentTime, MessageReadTime, ImageAttachment, ImageAttachmentURL)" +
                $" VALUES ( '{apiModel.SendBy}', '{apiModel.Message}', '{apiModel.MessageSentTime.UtcDateTime}', '', '{(apiModel.ImageAttachment ? '1' : '0')}', '{apiModel.ImageAttachmentURL}');";

            var result = await mContext.Database.ExecuteSqlCommandAsync(sqlQuery);

            if (result == 1)
                return result;

            // Create the name of the table
            var tableName2 = $"{SQLTableTypeHelpers.SQLTableTypeToString(type)}_{apiModel.SendTo}_{apiModel.SendBy}";

            var sqlQuery2 = $"IF EXISTS (SELECT * FROM sysobjects WHERE name='{tableName2}' and xtype='U')" +
                $" INSERT INTO {tableName2}" +
                $" ( SendBy, Message, MessageSentTime, MessageReadTime, ImageAttachment, ImageAttachmentURL)" +
                $" VALUES ( '{apiModel.SendBy}', '{apiModel.Message}', '{apiModel.MessageSentTime.UtcDateTime}', '', '{(apiModel.ImageAttachment ? '1' : '0')}', '{apiModel.ImageAttachmentURL}');";

            return await mContext.Database.ExecuteSqlCommandAsync(sqlQuery2);
        }

        [System.Obsolete]
        public static async Task<int> GetMessageFromTableAsync(this ApplicationDBContext mContext, MessageApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the name of the table
            var tableName = $"{SQLTableTypeHelpers.SQLTableTypeToString(type)}_{apiModel.SendBy}_{apiModel.SendTo}";

            var sqlQuery = $"IF EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')" +
                $" INSERT INTO {tableName}" +
                $" ( SendBy, Message, MessageSentTime, MessageReadTime, ImageAttachment, ImageAttachmentURL)" +
                $" VALUES ( '{apiModel.SendBy}', '{apiModel.Message}', '{apiModel.MessageSentTime.UtcDateTime}', '{apiModel.MessageReadTime.UtcDateTime.AddYears(2000)}', '{(apiModel.ImageAttachment ? '1' : '0')}', '{apiModel.ImageAttachmentURL}');";

            var result = await mContext.Database.ExecuteSqlCommandAsync(sqlQuery);

            if (result == 1)
                return result;

            // Create the name of the table
            var tableName2 = $"{SQLTableTypeHelpers.SQLTableTypeToString(type)}_{apiModel.SendTo}_{apiModel.SendBy}";

            var sqlQuery2 = $"IF EXISTS (SELECT * FROM sysobjects WHERE name='{tableName2}' and xtype='U')" +
                $" INSERT INTO {tableName2}" +
                $" ( SendBy, Message, MessageSentTime, MessageReadTime, ImageAttachment, ImageAttachmentURL)" +
                $" VALUES ( '{apiModel.SendBy}', '{apiModel.Message}', '{apiModel.MessageSentTime.UtcDateTime}', '{apiModel.MessageReadTime.UtcDateTime.AddYears(2000)}', '{(apiModel.ImageAttachment ? '1' : '0')}', '{apiModel.ImageAttachmentURL}');";

            return await mContext.Database.ExecuteSqlCommandAsync(sqlQuery2);
        }

        #endregion

        #region Private Helpers

        #region Create Table Methods

        [System.Obsolete]
        public static string CreateTableMessageHistoryAsync(CreateTableApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the name of the table
            var tableName = $"{SQLTableTypeHelpers.SQLTableTypeToString(type)}_{apiModel.Username}_{apiModel.SecondUser}";

            // SQL Query for server to create the table
            return $"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')" +
                $" CREATE TABLE {tableName}" +
                SQLCreateTableCommandsHelpers.SQLTableQueriesToString(type);
        }

        [System.Obsolete]
        public static string CreateTableFriendListAsync(CreateTableApiModel apiModel, SQLTableTypeEnum type)
        {
            // Create the name of the table
            var tableName = $"{SQLTableTypeHelpers.SQLTableTypeToString(type)}_{apiModel.Username}";

            // SQL Query for server to create the table
            return $"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')" +
                $" CREATE TABLE {tableName}" +
                SQLCreateTableCommandsHelpers.SQLTableQueriesToString(type);
        }

        [System.Obsolete]
        public static string CreateTableProfileSettingsAsync(CreateTableApiModel apiModel, SQLTableTypeEnum type)
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

        

        #endregion

        #endregion
    }
}
