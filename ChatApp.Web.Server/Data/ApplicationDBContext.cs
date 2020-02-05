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
        public DbSet<ContactsFriendListDataModel> ContactsFriendList { get; set; }

        #endregion

        /// <summary>
        /// Default constrcutor expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options = null) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API
            modelBuilder.Entity<ContactsFriendListDataModel>().HasIndex(a => a.Username).IsUnique();
        }

        
    }
}
