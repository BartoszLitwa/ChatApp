using System.ComponentModel.DataAnnotations;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Our Settings database table representational model
    /// </summary>
    public class SettingsDataModel
    {
        /// <summary>
        /// Unique ID for this entry
        /// </summary>
        [Key]
        public string ID { get; set; }

        /// <summary>
        /// The settings name
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// The settings value
        /// </summary>
        [Required]
        [MaxLength(1024)]
        public string Value { get; set; }
    }
}
