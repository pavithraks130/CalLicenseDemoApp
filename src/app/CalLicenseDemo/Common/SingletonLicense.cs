using System.Collections.Generic;
using CalLicense.Core.DatabaseContext;
using CalLicense.Core.Model;

namespace CalLicenseDemo.Common
{
    /// <summary>
    /// Singleton License object
    /// </summary>
    internal class SingletonLicense
    {
        private static SingletonLicense _instance;
        /// <summary>
        /// Feature list info property
        /// </summary>
        public List<Feature> FeatureList { get; set; }
        /// <summary>
        /// DB context property
        /// </summary>
        public LicenseAppDBContext Context { get; set; }

        /// <summary>
        /// User info property
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// It holds the information of subscription datails 
        /// </summary>
        public LicenseType SelectedSubscription { get; set; }

        /// <summary>
        /// single instance creation logic
        /// </summary>
        public static SingletonLicense Instance
        {
            get { return _instance ?? (_instance = new SingletonLicense()); }
        }

        /// <summary>
        /// Constructor logic
        /// </summary>
        public SingletonLicense()
        {
            FeatureList = new List<Feature>();
            Context = new LicenseAppDBContext();
            LicenseData = new LicenseJsonData();
        }

        /// <summary>
        /// License Json data property
        /// </summary>
        public LicenseJsonData LicenseData { get; set; }

        /// <summary>
        /// check teh user login status
        /// </summary>
        public bool IsUserLoggedIn { get; set; }

        /// <summary>
        /// Network status check.
        /// </summary>
        public bool IsNetworkAvilable
        {
            get { return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable(); }
        }
    }
}