using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.DatabaseContext
{
    public class LicenseAppDBContext : DbContext
    {
        public LicenseAppDBContext() : base("LicenseDatabase")
        {
        }

        public DbSet<Team> Team { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<LicenseType> LicenseType { get; set; }
        public DbSet<License> License { get; set; }
        public DbSet<UserLicense> UserLicense { get; set; }
        public DbSet<Feature> Feature { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}