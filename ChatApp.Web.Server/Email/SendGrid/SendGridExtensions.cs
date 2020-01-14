using ChatApp.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Extensions methods for any Sendgrid classes
    /// </summary>
    public static class SendGridExtensions
    {
        /// <summary>
        /// Injectes the <see cref="SendGridEmailSender"/> into the service to handle the
        /// <see cref="IEmailSender"/> service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            // Inject the SendGridEmailSender
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            // Return collection for chaining
            return services;
        }
    }
}
