using System.ComponentModel.DataAnnotations;

namespace ChatApp.Web.Server
{
    /// <summary>
    /// Our Settings database table representational model
    /// </summary>
    public class ContactsFriendListDataModel
    {
        /// <summary>
        /// Unique Username for this entry
        /// </summary>
        [Key]
        public string Username { get; set; }

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
