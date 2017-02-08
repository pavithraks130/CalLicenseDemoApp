using System;
using System.Collections.Generic;

namespace CalLicense.Core.Model
{
    /// <summary>
    ///     Model for storing the license details in the local system. Based on the subscription the features will be enabled.
    /// </summary>
    public class LicenseJsonData
    {
        public LicenseJsonData()
        {
            LicenseList = new List<LicenseDetails>();
        }

        public List<LicenseDetails> LicenseList { get; set; }
    }

    public class UserLicenseDetails
    {
        public int UserId { get; set; }
        public  LicenseJsonData LicenseDetails { get; set; }

        public UserLicenseDetails()
        {
            LicenseDetails = new LicenseJsonData();
        }
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