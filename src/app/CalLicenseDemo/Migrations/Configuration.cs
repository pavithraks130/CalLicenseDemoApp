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
                var feature1 = new Feature() { FeatureTitle = "Asset Manager" };
                var feature2 = new Feature() { FeatureTitle = "Report Gen" };
                var feature3 = new Feature() { FeatureTitle = "Procedure Editor" };
                var feature4 = new Feature() { FeatureTitle = "Test Execution" };
                var feature5 = new Feature() { FeatureTitle = "Christmas Gift" };
                var feature6 = new Feature() { FeatureTitle = "Device Configurator" };
                var feature7 = new Feature() { FeatureTitle = "Cloud Storage" };

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
                    TypeName = "Standard",
                    Price = 750,
                    ActiveDuration = 250,
                    FeatureList = new List<Feature>() { feature1, feature2, feature3, feature4, feature5 }
                });
                context.LicenseType.Add(new LicenseType()
                {
                    TypeName = "Ultimate",
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
