using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.Common
{
    class SingletonLicense
    {
        public List<Feature> FeatureList { get; set; }

        public  User User { get; set; }

        private static SingletonLicense _instance = null;
        public static SingletonLicense Instance
        {
            get { return _instance ?? (_instance = new SingletonLicense()); }
        }
    }
}
