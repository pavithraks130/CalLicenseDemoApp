using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.DatabaseContext
{
    public class LicenseAppDBContext : DbContext
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<LicenseType> LicenseType { get; set; }
        public DbSet<License> License { get; set; }
        public  DbSet<UserLicense> UserLicense { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
           .Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
