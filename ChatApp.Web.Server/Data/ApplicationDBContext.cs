using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// The database representational model for our application
    /// </summary>
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        #region Public Properties

        /// <summary>
        /// The Settings for the application
        /// </summary>
        public DbSet<SettingsDataModel> Settings { get; set; }

        #endregion

        /// <summary>
        /// Default constrcutor expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API
            modelBuilder.Entity<SettingsDataModel>().HasIndex(a => a.Name).IsUnique();
        }

        
    }
}
