using System;
using System.Collections.Generic;

namespace CalLicenseDemo.Model
{
    /// <summary>
    ///     Model for storing the license details in the local system. Based on the subscription the features will be enabled.
    /// </summary>
    public class UserLicenseJsonData
    {
        public UserLicenseJsonData()
        {
            LicenseList = new List<LicenseDetails>();
        }

        public List<LicenseDetails> LicenseList { get; set; }
    }

    public class LicenseDetails
    {
        public LicenseDetails()
        {
            Type = new LicenseType();
        }

        public string LicenseKey { get; set; }
        public LicenseType Type { get; set; }

        public DateTime ActivationDate { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}