using static Dna.FrameworkDI;

namespace ChatApp.Core
{
    /// <summary>
    /// Helpers methods for getting and working with web routes
    /// </summary>
    public static class RouteHelpers
    {
        /// <summary>
        /// Converts the relative URL to absolute
        /// </summary>
        /// <param name="relativeUrl">The relative URL</param>
        /// <returns>Returns the absolute URL including the Host URL</returns>
        public static string GetAbsoluteRoute(string relativeUrl)
        {
            // Get the host
            var host = Configuration["ChatAppServer:HostUrl"];

            // If tere isnt passed any URL
            if (string.IsNullOrEmpty(relativeUrl))
                // return the host
                return host;

            // If the relative URL does not start with /
            if (!relativeUrl.StartsWith("/"))
                // Add / to the start of the passed URL
                relativeUrl.Insert(0, "/");

            // Return the absolute URL
            return host + relativeUrl;
        }
    }
}
