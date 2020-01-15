using ChatApp.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Manages the WEB API Calls
    /// </summary>
    public class ApiController : Controller
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
        public ApiController(ApplicationDBContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        #region Pages Method

        /// <summary>
        /// Tries to register for a new account on the server
        /// </summary>
        /// <param name="registerCredentials">The registration details</param>
        /// <returns>Returns teh result of the register request</returns>
        [Route("api/register")]
        public async Task<ApiResponse<RegisterResultApiModel>> RegisterAsync([FromBody] RegisterCredentialsApiModel registerCredentials)
        {
            // TODO: Localize all strings
            // The message when we failed to login
            var invalidErrorMessage = "Please provide all required details to register an account";

            // The error message for a failed login
            var errorResponse = new ApiResponse<RegisterResultApiModel>
            {
                // Set error message
                ErrorMessage = invalidErrorMessage
            };

            // Make sure we have a register credentials
            if (registerCredentials == null)
                // Return failed response
                return errorResponse;

            // Make sure we have a user name
            if (string.IsNullOrWhiteSpace(registerCredentials.Username))
                return errorResponse;

                // Create the desired user from the given details
            var user = new ApplicationUser
            {
                UserName = registerCredentials.Username,
                FirstName = registerCredentials.FirstName,
                LastName = registerCredentials.LastName,
                Email = registerCredentials.Email,
            };

            // Try and create a user
            var result = await mUserManager.CreateAsync(user, registerCredentials.Password);

            // If the registration was succesful
            if (result.Succeeded)
            {
                // Get the user details
                var userIdentity = await mUserManager.FindByNameAsync(registerCredentials.Username);

                // Generate an email verification code
                var emailVerificationCode = await mUserManager.GenerateEmailConfirmationTokenAsync(user);

                // TODO: Replace with APIRoutes that will contain the static routes to use
                var confirmationUrl = $"https://{Request.Host.Value}/api/verify/email/{HttpUtility.UrlEncode(userIdentity.Id)}/{HttpUtility.UrlEncode(emailVerificationCode)}";

                // Email the user the verification code
                await ChatAppEmailSender.SendUserVerificationEmailAsync(userIdentity.FirstName, userIdentity.Email, confirmationUrl);

                // return valid response conataining all users details
                return new ApiResponse<RegisterResultApiModel>
                {
                    Response = new RegisterResultApiModel
                    {
                        FirstName = userIdentity.FirstName,
                        LastName = userIdentity.LastName,
                        Email = userIdentity.Email,
                        Username = userIdentity.UserName,
                        Token = userIdentity.GenerateJwtToken()
                    }
                };
            }
            // Otherwise
            else
                // Return the failed error
                return new ApiResponse<RegisterResultApiModel>
                {
                    // Aggregate all errors into a single error string
                    ErrorMessage = result.Errors.ToList().Select(f => f.Description).Aggregate((a,b) => $"{a}{Environment.NewLine}{b}")
                };
        }

        [HttpGet]
        [Route("api/verify/email/{userId}/{emailToken}")]
        public async Task<ActionResult> VerifyEmailAsync(string userId, string emailToken)
        {
            // Get the user
            var user = await mUserManager.FindByIdAsync(userId);

            // NOTE: Issue at the minute with Url Decoding that contains /'s does not replace them
            //       https://github.com/aspnet/Home/issues/2669
            //       For now, manually fix that
            emailToken = emailToken.Replace("%2f", "/").Replace("%2F", "/");

            // If the user is null
            if (user == null)
                // TODO: Nice UI
                return Content("User not found");

            // If we have the user...
            // Verify the email token
            var result = await mUserManager.ConfirmEmailAsync(user, emailToken);

            // If succeeded...
            if (result.Succeeded)
                // TODO: Nice UI
                return Content("Email Verified :)");

            // TODO: Nice UI
            return Content("Invalid Email Verification Token :(");
        }

        /// <summary>
        /// Logs in a user using token based authentication
        /// </summary>
        /// <param name="loginCredentials"></param>
        /// <returns></returns>
        [Route("api/login")]
        public async Task<ApiResponse<LoginResultApiModel>> LoginAsync([FromBody]LoginCredentialsApiModel loginCredentials)
        {
            // TODO: Localize all strings
            // The message when we failed to login
            var invalidErrorMessage = "Invalid username or password";

            // The error message for a failed login
            var errorResponse = new ApiResponse<LoginResultApiModel>
            {
                // Set error message
                ErrorMessage = invalidErrorMessage
            };

            // Make sure we have a user name
            if (loginCredentials?.UsernameOrEmail == null || string.IsNullOrWhiteSpace(loginCredentials.UsernameOrEmail))
                return errorResponse;

            // Validate if the user credentials are correct

            // Is it an email?
            var isEmail = loginCredentials.UsernameOrEmail.Contains("@");

            // Get the users details. If email find by email, otheriwse by name
            var user = isEmail ? await mUserManager.FindByEmailAsync(loginCredentials.UsernameOrEmail) : await mUserManager.FindByNameAsync(loginCredentials.UsernameOrEmail);

            // If we failed to find an user
            if (user == null)
                return errorResponse;

            // If we got here we have a user. Validate the users password
            var isValidPassword = await mUserManager.CheckPasswordAsync(user, loginCredentials.Password);

            // If the password is invalid
            if (!isValidPassword)
                return errorResponse;

            // If we got there the user passed correct login details

            // return valid response conataining all users details
            return new ApiResponse<LoginResultApiModel>
            {
                Response = new LoginResultApiModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Username = user.UserName,
                    Token = user.GenerateJwtToken()
                }
            };
        }

        [AuthorizeToken]
        [Route("api/private")]
        public IActionResult Private()
        {
            var user = HttpContext.User;

            return Ok(new { privateData = $"The most secret private data handled by api for {user.Identity.Name}!" });
        } 

        #endregion
    }
}
