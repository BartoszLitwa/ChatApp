using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Set the authorize as Json Web Token
    /// </summary>
    public class AuthorizeTokenAttribute : AuthorizeAttribute
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AuthorizeTokenAttribute()
        {
            // Add the JWT bearer authentication scheme
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }

        #endregion
    }
}
