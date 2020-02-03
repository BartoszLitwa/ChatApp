using System.Data.Entity.Migrations;

namespace ChatApp.Web.Server
{
    public class AddTableMigration : DbMigration
    {
        #region Public Properties

        /// <summary>
        /// The username of the user that has started chatting 
        /// </summary>
        public string FirstUsername { get; set; }

        /// <summary>
        /// The username of the second user
        /// </summary>
        public string SecondUsername { get; set; }

        #endregion

        #region Constrcuctor

        /// <summary>
        /// Default Constuctor
        /// </summary>
        public AddTableMigration(string firstUser, string seocndUser)
        {
            FirstUsername = firstUser;
            SecondUsername = seocndUser;
        }

        #endregion

        /// <summary>
        /// Generate the new table for a chat message history between 2 users
        /// </summary>
        public override void Up()
        {
            CreateTable("dbo.test", c => new
            {
                Id = c.Int(nullable: false, identity: true),
                SentBy = c.String(maxLength: 100),
                Message = c.String(maxLength: 2000),
                MessageSentTime = c.DateTime(nullable: false),
                MessageReadTime = c.DateTime(),
                ImageAttachment = c.Boolean(),
                ImageAttachmentUrl = c.String(nullable: true)
            }).PrimaryKey(p => p.Id)
            .Index(i => i.Id);
        }
    }
}
