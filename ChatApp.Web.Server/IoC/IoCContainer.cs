using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ChatApp.Core;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// A shorthand acces class to get DI services with nice clean short code
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// The scoped instance of the <see cref="ApplicationDBContext"/>
        /// </summary>
        public static ApplicationDBContext ApplicationDBContext => IoCContainer.Provider.GetService<ApplicationDBContext>();

        /// <summary>
        /// The transient instance of the <see cref="IEmailSender"/>
        /// </summary>
        public static IEmailSender EmailSender => IoCContainer.Provider.GetService<IEmailSender>();

        /// <summary>
        /// The transient instance of the <see cref="IEmailTemplateSender"/>
        /// </summary>
        public static IEmailTemplateSender EmailTemplateSender => IoCContainer.Provider.GetService<IEmailTemplateSender>();
    }

    /// <summary>
    /// The Dependency injection container making use of the built in .Net Core service provider
    /// </summary>
    public static class IoCContainer
    {
        /// <summary>
        /// The service provider for this application
        /// </summary>
        public static IServiceProvider Provider { get; set; }

        /// <summary>
        /// The configuration manager for the application
        /// </summary>
        public static IConfiguration Configuration { get; set; }

    }
}
