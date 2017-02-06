using System.Collections.Generic;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CalLicenseDemo.DatabaseContext.LicenseAppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CalLicenseDemo.DatabaseContext.LicenseAppDBContext context)
        {
            bool DbIntialized =
                 Convert.ToBoolean(System.Configuration.ConfigurationSettings.AppSettings.Get("DbIntialized"));
            if (DbIntialized)
            {
                var feature1 = new Feature() { FeatureTitle = "Feature1" };
                var feature2 = new Feature() { FeatureTitle = "Feature2" };
                var feature3 = new Feature() { FeatureTitle = "Feature3" };
                var feature4 = new Feature() { FeatureTitle = "Feature4" };
                var feature5 = new Feature() { FeatureTitle = "Feature5" };
                var feature6 = new Feature() { FeatureTitle = "Feature6" };
                var feature7 = new Feature() { FeatureTitle = "Feature7" };

                context.Feature.Add(feature1);
                context.Feature.Add(feature2);
                context.Feature.Add(feature3);
                context.Feature.Add(feature4);
                context.Feature.Add(feature5);
                context.Feature.Add(feature6);
                context.Feature.Add(feature7);


                context.LicenseType.Add(new LicenseType()
                {
                    TypeName = "Trial",
                    Price = 0,
                    ActiveDuration = 30,
                    FeatureList = new List<Feature>() { feature1, feature2, feature3 }
                });
                context.LicenseType.Add(new LicenseType()
                {
                    TypeName = "Subscription1",
                    Price = 750,
                    ActiveDuration = 250,
                    FeatureList = new List<Feature>() { feature1, feature2, feature3, feature4, feature5 }
                });
                context.LicenseType.Add(new LicenseType()
                {
                    TypeName = "SUbscription2",
                    Price = 1200,
                    ActiveDuration = 365,
                    FeatureList =
                        new List<Feature>() { feature1, feature2, feature3, feature4, feature5, feature6, feature7 }
                });
                context.SaveChanges();
            }
        }
    }
}
