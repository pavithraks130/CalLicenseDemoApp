using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Newtonsoft.Json;

namespace CalLicense.Core.Model
{
    /// <summary>
    /// This is used to hold user record collection
    /// </summary>
    public class User
    {
        /// <summary>
        /// Constructor details
        /// </summary>
        public User()
        {
            FName = string.Empty;
            LName = string.Empty;
            Email = string.Empty;
            PasswordHash = String.Empty;
            ThumbPrint = string.Empty;
        }

        /// <summary>
        /// user id
        /// </summary>
        [Key]
        public int UserId { get; set; }
        /// <summary>
        /// First name
        /// </summary>
        public string FName { get; set; }
        /// <summary>
        /// Last name property
        /// </summary>
        public string LName { get; set; }
        /// <summary>
        /// Email id property
        /// </summary>
        [Index("Ix_EmailUniqueKey", 1, IsUnique = true)]
        [MaxLength(500)]
        public string Email { get; set; }
        /// <summary>
        /// Password hash details property
        /// </summary>
        public string PasswordHash { get; set; }
        /// <summary>
        /// password thumbprint property
        /// </summary>
        public string ThumbPrint { get; set; }
        /// <summary>
        /// Team id property
        /// </summary>
        public int TeamId { get; set; }
        /// <summary>
        /// Organization property
        /// </summary>
        [ForeignKey("TeamId")]
        public virtual Team Organization { get; set; }
        /// <summary>
        /// Licenses details property
        /// </summary>
        [JsonIgnore]
        public virtual List<UserLicense> Licenses { get; set; }
    }

    public class RegistrationModel
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string OrganizationName { get; set; }
    }
    /// <summary>
    /// Team details
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Constructor data initialization
        /// </summary>
        public Team()
        {
            TeamId = 0;
            Name = string.Empty;
            GroupEmail = string.Empty;
        }

        /// <summary>
        /// Team id property
        /// </summary>
        [Key]
        public int TeamId { get; set; }

        /// <summary>
        /// Team name property
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Group email is property
        /// </summary>
        public string GroupEmail { get; set; }
    }
}