using ChatApp.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChatApp.Web.Server
{
    [AuthorizeToken]
    public class ContactsController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The scoped Application context
        /// </summary>
        protected ApplicationDBContext mContext;

        /// <summary>
        /// The manager for handling users creation, deletion, searching, roles etc...
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;

        /// <summary>
        /// The manager for handling signinig in and out for our users
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Default contsructor
        /// </summary>
        /// <param name="context">The injected context</param>
        /// <param name="signInManager">The Identity sign in manager</param>
        /// <param name="userManager">The Identity user manager</param>
        public ContactsController(ApplicationDBContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        // GET: Contacts
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [Route(ContactsRoutes.Create)]
        [System.Obsolete]
        public async Task<ApiResponse> CreateAsync([FromBody] CreateMessageHisotryApiModel apiModel)
        {
            var result = await CreateTableAsync(apiModel.FirstUser, apiModel.SecondUser);

            return new ApiResponse
            {
                ErrorMessage = ""
            };
        }

        [Route(ContactsRoutes.SendMessage)]
        [System.Obsolete]
        public async Task<ApiResponse> SendMessageAsync([FromBody] CreateMessageHisotryApiModel apiModel)
        {
            var result = await CreateTableAsync(apiModel.FirstUser, apiModel.SecondUser);

            return new ApiResponse
            {
                ErrorMessage = ""
            };
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        #region Private Helpers

        [System.Obsolete]
        private async Task<int> CreateTableAsync(string firstUser, string secondUser)
        {
            // Create the name of the table
            var tableName = $"dbo.MessageHistory_{firstUser}_{secondUser}";

            var sqlQuery = $"IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='{tableName}' and xtype='U')" +
                $" CREATE TABLE {tableName}" +
                $" ( ID int PRIMARY KEY IDENTITY(0,1) ," +
                $" SendBy varchar(100) NOT NULL," +
                $" Message varchar(2000) NOT NULL," +
                $" MessageSentTime DATETIME NOT NULL," +
                $" MessageReadTime DATETIME NOT NULL, " +
                $" ImageAttachment int NOT NULL, " +
                $" ImageAttachmentURL varchar(200) );";

            return await mContext.Database.ExecuteSqlCommandAsync(sqlQuery);
        }

        #endregion
    }
}