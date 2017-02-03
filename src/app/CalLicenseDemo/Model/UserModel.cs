using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalLicenseDemo.Model
{
    public class User
    {
        public User()
        {
            FName = string.Empty;
            LName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Organization = new Team();
            Licenses = new List<UserLicense>();
        }

        [Key]
        public int UserId { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int TeamID { get; set; }

        [ForeignKey("TeamID")]
        public virtual Team Organization { get; set; }

        public virtual List<UserLicense> Licenses { get; set; }
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