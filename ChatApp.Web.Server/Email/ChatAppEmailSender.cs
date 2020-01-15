using System.Threading.Tasks;
using ChatApp.Core;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Handles sending emails specific to the ChatApp server
    /// </summary>
    public static class ChatAppEmailSender
    {
        /// <summary>
        /// Sends a verification email to the specified user
        /// </summary>
        /// <param name="displayName">The users display name(typically First Name)</param>
        /// <param name="email">The users email to be verified</param>
        /// <param name="verificationUrl">The URL the user needs to click to verify their emails</param>
        /// <returns></returns>
        public static async Task<SendEmailResponse> SendUserVerificationEmailAsync(string displayName, string email, string verificationUrl)
        {
            await IoC.EmailTemplateSender.SendGeneralEmailAsync(new SendEmailDetails
            {
                IsHTML = true,
                FromEmail = IoCContainer.Configuration["ChatAppSettings:SendEmailFromEmail"],
                FromName = IoCContainer.Configuration["ChatAppSettings:SendEmailFromName"],
                ToEmail = email,
                Subject = "Verify Your Email! - ChatApp"
            },
            "Verify Your Email",
            $"Hi {displayName ?? "stranger"},",
            "Thanks for creating an account with us. <br/> To continue please verify your email.",
            "Verify Email",
            verificationUrl);

            return new SendEmailResponse();
        }
    }
}
