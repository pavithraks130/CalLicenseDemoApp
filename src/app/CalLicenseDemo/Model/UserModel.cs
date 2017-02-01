using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace CalLicenseDemo.Model
{
    public class User
    {
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

        public User()
        {
            FName = string.Empty;
            LName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Organization = new Team();
            Licenses = new List<UserLicense>();

        }
    }

    public class Team
    {
        [Key]
        public  int TeamId { get; set; }
        public string Name { get; set; }
        public string GroupEmail { get; set; }

        public Team()
        {
            TeamId = 0;
            Name = string.Empty;
            GroupEmail = string.Empty;
        }
    }
}
