using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Extension methods for <see cref="IdentityError"/> class
    /// </summary>
    public static class IdentityErrorExtensions
    {
        /// <summary>
        /// Combines all erros int o a single 
        /// </summary>
        /// <param name="errors">The errors to aggregate</param>
        /// <returns>Returns a string with each error separated by a new line</returns>
        public static string AggregateErrors(this IEnumerable<IdentityError> errors)
        {
            // Get all erros into a list
            return errors?.ToList().
                // Grab their description
                Select(f => f.Description).
                // And combine them with a new line separator
                Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");
        }
    }
}
