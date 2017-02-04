using System.Data.Entity.Migrations;
using System.Linq;
using CalLicenseDemo.DatabaseContext;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LicenseAppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LicenseAppDBContext context)
        {
            if (!context.Feature.Any())
            {
                context.Feature.Add(new Feature() {FeatureTitle = "Feature1"});
                context.Feature.Add(new Feature() {FeatureTitle = "Feature2"});
                context.Feature.Add(new Feature() {FeatureTitle = "Feature3"});
                context.Feature.Add(new Feature() {FeatureTitle = "Feature4"});
                context.Feature.Add(new Feature() {FeatureTitle = "Feature5"});
                context.Feature.Add(new Feature() {FeatureTitle = "Feature6"});
                context.Feature.Add(new Feature() {FeatureTitle = "Feature7"});
            }

            if (context.LicenseType.Any()) return;
            context.LicenseType.Add(new LicenseType() {TypeName = "Free", Price = 0});
            context.LicenseType.Add(new LicenseType() {TypeName = "Subscription1", Price = 750});
            context.LicenseType.Add(new LicenseType() {TypeName = "SUbscription2", Price = 1200});

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}