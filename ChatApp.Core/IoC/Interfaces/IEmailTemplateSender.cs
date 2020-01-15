using System.Threading.Tasks;

namespace ChatApp.Core
{
    /// <summary>
    /// Sends emails using the <see cref="IEmailSender"/> and creating the HTML
    /// email from specific templates
    /// </summary>
    public interface IEmailTemplateSender
    {
        /// <summary>
        /// Sends an email with the given details using the General template
        /// </summary>
        /// <param name="details">The email message details. Content is ignored and replaced by template</param>
        /// <param name="title">The title</param>
        /// <param name="Username">The first line content</param>
        /// <param name="Content">the second line content</param>
        /// <param name="ButtonText">The button text</param>
        /// <param name="ButtonUrl">The button URL</param>
        /// <param name="Type">The type of service to send emails</param>
        /// <returns></returns>
        Task<SendEmailResponse> SendGeneralEmailAsync(SendEmailDetails details, string title, string Username, string Content, string ButtonText, string ButtonUrl, TemplateEmailSenderType Type = TemplateEmailSenderType.SendGrid);
    }
}
