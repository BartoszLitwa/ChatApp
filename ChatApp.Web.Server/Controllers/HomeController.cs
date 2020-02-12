using ChatApp.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Manages teh standard web server pages
    /// </summary>
    public class HomeController : Controller
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

        #region Constrcuctor

        /// <summary>
        /// Default contsructor
        /// </summary>
        /// <param name="context">The injected context</param>
        /// <param name="signInManager">The Identity sign in manager</param>
        /// <param name="userManager">The Identity user manager</param>
        public HomeController(ApplicationDBContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        public IActionResult Index()
        {
            // Make sure we have the database
            mContext.Database.EnsureCreated();

            return View();
        }

        /// <summary>
        /// Creates our single user for now
        /// </summary>
        /// <returns></returns>
        [Route(WebRoutes.CreateUser)]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await mUserManager.CreateAsync(new ApplicationUser
            {
                UserName = "CRNYY",
                Email = "Test@Email.com",
                FirstName = "Bartosz",
                LastName = "Litwa",
            }, "password");

            if(result.Succeeded)
                return Content("User was created", "text/html");

            return Content("User wasn't created", "text/html");
        }

        /// <summary>
        /// Private area. No peeking
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route(WebRoutes.Private)]
        public IActionResult Private()
        {
            return Content($"This is private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }

        /// <summary>
        /// An auto-login page for testing
        /// </summary>
        /// <param name="ReturnUrl">The url to return to if succesfully logged in</param>
        /// <returns></returns>
        [Route(WebRoutes.Login)]
        public async Task<IActionResult> LoginAsync(string ReturnUrl)
        {
            // Sing out any previous sessions
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            // Sign user in with the valid credentials
            var result = await mSignInManager.PasswordSignInAsync("CRNYY", "password", true, false);

            // If successful
            if (result.Succeeded)
                // If we have no return url go to home. Otheriwse go to the retrunurl
                return string.IsNullOrEmpty(ReturnUrl) ? RedirectToAction(nameof(Index)) : RedirectToAction(ReturnUrl);

            return Content("Failed to Login!", "text/html");
        }

        [Route(WebRoutes.LogOut)]
        public async Task<IActionResult> LogOutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return Content("Signed Out!");
        }

        [Route(WebRoutes.WebpageReachable)]
        public IActionResult WebPageReachable()
        {
            return Content("Reachable");
        }
    }
}
