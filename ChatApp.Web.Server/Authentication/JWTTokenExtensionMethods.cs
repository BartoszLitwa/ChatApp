using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Extensions methods for working with JWT bearer tokens
    /// </summary>
    public static class JWTTokenExtensionMethods
    {
        /// <summary>
        /// Generates the JWT bearer containing the users username
        /// </summary>
        /// <param name="user">The users detials</param>
        /// <returns></returns>
        public static string GenerateJwtToken(this ApplicationUser user)
        {
            // Set out tokens claims
            var Claims = new[]
            {
                // Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                // The username using the Identity name so it fills out the HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
            };

            // Create Credentials used to generate the token
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoCContainer.Configuration["Jwt:SecretKey"])),
                SecurityAlgorithms.HmacSha256);

            // Generate the Jwt Token
            var token = new JwtSecurityToken(
                issuer: IoCContainer.Configuration["Jwt:Issuer"],
                audience: IoCContainer.Configuration["Jwt:Issuer"],
                claims: Claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: credentials);

            // Return the generated token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
