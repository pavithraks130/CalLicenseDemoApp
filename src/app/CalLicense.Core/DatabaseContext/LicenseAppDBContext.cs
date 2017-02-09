using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CalLicense.Core.Model;

namespace CalLicense.Core.DatabaseContext
{
    public class LicenseAppDBContext : DbContext
    {
        public LicenseAppDBContext() : base("LicenseDatabase")
        {
            //Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
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