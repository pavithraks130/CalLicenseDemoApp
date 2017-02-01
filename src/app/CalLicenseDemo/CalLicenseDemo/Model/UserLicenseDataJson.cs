using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.Model
{
    /// <summary>
    /// Model for storing the license details in the local system. Based on the subscription the features will be enabled.
    /// </summary>
    public class UserLicenseJsonData
    {
        public List<LicenseDetails> LicenseList { get; set; }

        public UserLicenseJsonData()
        {
            LicenseList = new List<LicenseDetails>();
        }

    }

    public class LicenseDetails
    {
        public string LicenseKey { get; set; }
        public LicenseType Type { get; set; }

        public DateTime ActivationDate { get; set; }

        public DateTime ExpireDate { get; set; }
        public LicenseDetails()
        {
            Type = new LicenseType();
        }


    }
}
