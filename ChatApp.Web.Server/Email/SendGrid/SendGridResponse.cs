using System.Collections.Generic;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// A response to a SendGrid Send Message call
    /// </summary>
    public class SendGridResponse
    {
        /// <summary>
        /// Any errors from a response
        /// </summary>
        public List<SendGridResponseError> Error { get; set; }
    }
}
