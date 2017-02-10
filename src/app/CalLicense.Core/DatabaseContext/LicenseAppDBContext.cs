using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CalLicense.Core.Model;

namespace CalLicense.Core.DatabaseContext
{
    /// <summary>
    /// LicenseApp DBContext creation for database activity.
    /// </summary>
    public class LicenseAppDBContext : DbContext
    {
        /// <summary>
        /// LicenseAppDBContext constructor data initialization
        /// </summary>
        public LicenseAppDBContext() : base("LicenseDatabase")
        {
            //Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
        }

        /// <summary>
        /// DB set creation for Team model class
        /// </summary>
        public DbSet<Team> Team { get; set; }
        /// <summary>
        /// Db set creation for User Model class
        /// </summary>
        public DbSet<User> User { get; set; }
        /// <summary>
        /// Db set creation for LicenseType model class
        /// </summary>
        public DbSet<LicenseType> LicenseType { get; set; }

        /// <summary>
        /// Db set creation for License model class
        /// </summary>
        public DbSet<License> License { get; set; }
        /// <summary>
        /// Db set creation for UserLicense model class
        /// </summary>
        public DbSet<UserLicense> UserLicense { get; set; }

        /// <summary>
        /// Db set creation for Feature model class
        /// </summary>
        public DbSet<Feature> Feature { get; set; }

        /// <summary>
        /// Used to restrict the default naming convention.
        /// Ex :"User" table after data migration by default it changes to "Users".
        /// </summary>
        /// <param name="modelBuilder">modelBuilder param</param>

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}