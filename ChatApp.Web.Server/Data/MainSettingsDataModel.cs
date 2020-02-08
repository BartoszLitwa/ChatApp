using System.ComponentModel.DataAnnotations;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Our Settings database table representational model
    /// </summary>
    public class MainSettingsDataModel
    {
        /// <summary>
        /// Unique Username for this entry
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        /// The current version
        /// </summary>
        [Required]
        [MaxLength(64)]
        public string Version { get; set; }

        /// <summary>
        /// The current number of people registered
        /// </summary>
        public int CurrentUsers { get; set; }
    }
}
