using System.Collections.Generic;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.Common
{
    internal class SingletonLicense
    {
        private static SingletonLicense _instance;
        public List<Feature> FeatureList { get; set; }

        public User User { get; set; }

        public  LicenseType SelectedSubscription { get; set; }

        public static SingletonLicense Instance
        {
            get { return _instance ?? (_instance = new SingletonLicense()); }
        }

        public SingletonLicense()
        {
            FeatureList = new List<Feature>();
        }
    }
}