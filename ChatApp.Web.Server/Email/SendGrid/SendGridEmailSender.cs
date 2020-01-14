using ChatApp.Core;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Sends emails using the SendGrid service
    /// </summary>
    public class SendGridEmailSender : IEmailSender
    {
        public async Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details)
        {
            // Get the Send Grid key
            var apiKey = IoCContainer.Configuration["SendGridKey"];

            // Create a new SendGrid client
            var client = new SendGridClient(apiKey);

            // Set the from details
            var from = new EmailAddress(details.FromEmail, details.FromName);

            // Set the to details
            var to = new EmailAddress(details.ToEmail, details.ToName);

            // Set the subject
            var subject = details.Subject;

            // Set the content
            var Content = details.Content;

            // Create Email class ready to send
            var msg = MailHelper.CreateSingleEmail(from, to, subject, details.IsHTML ? null : Content, details.IsHTML ? Content : null);

            // Send the email
            var response = await client.SendEmailAsync(msg);

            // If we succeeded
            if(response.StatusCode == HttpStatusCode.Accepted)
                // Return successful response
                return new SendEmailResponse();

            // Otherwise it failed
            try
            {
                // Get the result body
                var bodyResult = await response.Body.ReadAsStringAsync();

                // Deserialize the response
                var sendGridResponse = JsonConvert.DeserializeObject<SendGridResponse>(bodyResult);

                // Add any errors to the response
                var errorResponse = new SendEmailResponse
                {
                    Errors = sendGridResponse?.Error.Select(f => f.Message).ToList()
                };

                // Make sure we have at least 1 error
                if (errorResponse.Errors == null || errorResponse.Errors.Count == 0)
                    // Add an unknow error
                    errorResponse.Errors = new List<string>(new[] { "Unknown error from email sending service. Please contact ChatApp Developer." });

                // Return the response
                return errorResponse;
            }
            catch (Exception ex)
            {
                // TODO: Localize texts

                // Break if we are debugging
                if (Debugger.IsAttached)
                    Debugger.Break();

                // If something unexpected happend, return the message
                return new SendEmailResponse
                {
                    Errors = new List<string>(new[] { "Unknown error occured" })
                };
            }
        }
    }
}
