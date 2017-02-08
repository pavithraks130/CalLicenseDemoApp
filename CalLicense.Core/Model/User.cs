using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Newtonsoft.Json;

namespace CalLicense.Core.Model
{
    public class User
    {
        public User()
        {
            FName = string.Empty;
            LName = string.Empty;
            Email = string.Empty;
            PasswordHash = String.Empty;
            ThumbPrint = string.Empty;
        }

        [Key]
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [Index("Ix_EmailUniqueKey", 1, IsUnique = true)]
        [MaxLength(500)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ThumbPrint { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Organization { get; set; }
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

    public class Team
    {
        public Team()
        {
            TeamId = 0;
            Name = string.Empty;
            GroupEmail = string.Empty;
        }

        [Key]
        public int TeamId { get; set; }

        public string Name { get; set; }
        public string GroupEmail { get; set; }
    }
}