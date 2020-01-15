namespace ChatApp.Core
{
    /// <summary>
    /// Types of templated emails senders
    /// </summary>
    public enum TemplateEmailSenderType
    {
        /// <summary>
        /// Send using a SendGrid
        /// </summary>
        SendGrid = 0,

        /// <summary>
        /// Send using SMTP Client
        /// </summary>
        Smtp = 1
    }
}
