using ChatApp.Core;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Handles sending templated Emails
    /// </summary>
    public class EmailTemplateSender : IEmailTemplateSender
    {
        public async Task<SendEmailResponse> SendGeneralEmailAsync(SendEmailDetails details, string title, string Username, string Content, string ButtonText, string ButtonUrl, TemplateEmailSenderType Type = TemplateEmailSenderType.SendGrid)
        {
            var templateText = default(string);
            // Read the general template from file
            // TODO: Replace with IoC Flat Data provider
            using (var reader = new StreamReader(Assembly.GetEntryAssembly().GetManifestResourceStream("ChatApp.Web.Server.Email.Templates.GeneralTemplate.html"), Encoding.UTF8))
            {
                // Read file contents
                templateText = await reader.ReadToEndAsync();
            }

            // Replace special values with those inside the template
            templateText = templateText.Replace("---Title---", title)
                                       .Replace("---Username---", Username)
                                       .Replace("---Content---", Content)
                                       .Replace("---ButtonText---", ButtonText)
                                       .Replace("---ButtonUrl---", ButtonUrl);

            // Set the details content to this template content
            details.Content = templateText;

            // Send Email
            switch (Type)
            {
                // Send using SendGrid
                case TemplateEmailSenderType.SendGrid:
                    return await IoC.EmailSender.SendEmailAsync(details);

                // Send usign SMTP Client
                case TemplateEmailSenderType.Smtp:
                    return await IoC.EmailSender.SendSmtpEmailAsync(details);

                default:
                    return await IoC.EmailSender.SendEmailAsync(details);
            }
        }
    }
}
