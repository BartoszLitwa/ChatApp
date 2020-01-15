﻿using ChatApp.Core;
using Dna;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Relational
{
    /// <summary>
    /// Extension methods for the <see cref="FrameworkConstruction"/>
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public static FrameworkConstruction AddClientDataStore(this FrameworkConstruction construction)
        {
            // Inject our SQLite EF data store
            construction.Services.AddDbContext<ClientDataStoreDbContext>(options =>
            {
                // Setup connection string
                options.UseSqlite("Data Source=ChatApp.db");
            });

            // Add client data store for easy access/use of the backing data store
            // Make it scoped so we can inject the scoped DbContext
            construction.Services.AddScoped<IClientDataStore>(
                provider => new BaseClientDataStore(provider.GetService<ClientDataStoreDbContext>()));

            // Return framework for chaining
            return construction;
        }
    }
}
