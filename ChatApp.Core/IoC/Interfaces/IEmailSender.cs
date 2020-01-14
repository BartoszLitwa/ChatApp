﻿using System.Threading.Tasks;

namespace ChatApp.Core
{
    /// <summary>
    /// A service that handles sending emails of the caller
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an email message with the given information
        /// </summary>
        /// <param name="details">The details about the email to send</param>
        /// <returns></returns>
        Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details);
    }
}
