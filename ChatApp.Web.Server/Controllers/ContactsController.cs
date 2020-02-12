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

        #region Create Table

        [Route(ContactsRoutes.CreateMessageHistory)]
        [System.Obsolete]
        public async Task<ApiResponse> CreateMessageHistoryAsync([FromBody] TableApiModel apiModel)
        {
            var result = await mContext.CreateTableAsync(apiModel, SQLTableTypeEnum.MessageHistory);

            return new ApiResponse
            {
            };
        }

        [Route(ContactsRoutes.CreateFriendList)]
        [System.Obsolete]
        public async Task<ApiResponse> CreateFriendListAsync([FromBody] TableApiModel apiModel)
        {
            var result = await mContext.CreateTableAsync(apiModel, SQLTableTypeEnum.FriendList);

            return new ApiResponse
            {
            };
        }

        [Route(ContactsRoutes.CreateProfileSettings)]
        [System.Obsolete]
        public async Task<ApiResponse> CreateProfileSettingsAsync([FromBody] TableApiModel apiModel)
        {
            var result = await mContext.CreateTableAsync(apiModel, SQLTableTypeEnum.ProfileSettings);

            return new ApiResponse
            {
            };
        }

        #endregion

        [Route(ContactsRoutes.SendMessage)]
        [System.Obsolete]
        public async Task<ApiResponse> SendMessageAsync([FromBody] MessageApiModel apiModel)
        {
            // Create empty error message
            var Error = default(string);

            // Send the message
            var result = await mContext.InsertIntoTableAsync(apiModel, SQLTableTypeEnum.MessageHistory);

            // If any row has been affected it means that there isnt any table for this chat
            if (result < 1)
                Error = $"Error occured while sending the message to {apiModel.SendTo}";

            // Return the new api response
            return new ApiResponse
            {
                ErrorMessage = Error
            };
        }
    }
}