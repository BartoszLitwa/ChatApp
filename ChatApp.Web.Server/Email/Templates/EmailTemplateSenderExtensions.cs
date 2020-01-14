using Microsoft.Extensions.DependencyInjection;
using ChatApp.Core;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Extensions methods for any EmailTemplateSender class
    /// </summary>
    public static class EmailTemplateSenderExtensions
    {
        /// <summary>
        /// Injectes the <see cref="EmailTemplateSender"/> into the service to handle the
        /// <see cref="IEmailTemplateSender"/> service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddEmailTemplateSender(this IServiceCollection services)
        {
            // Inject the SendGridEmailSender
            services.AddTransient<IEmailTemplateSender, EmailTemplateSender>();

            // Return collection for chaining
            return services;
        }
    }
}
