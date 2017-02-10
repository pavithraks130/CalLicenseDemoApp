using System;
using System.Collections.Generic;

namespace CalLicense.Core.Model
{
    /// <summary>
    ///     Model for storing the license details in the local system. Based on the subscription the features will be enabled.
    /// </summary>
    public class LicenseJsonData
    {

        /// <summary>
        /// LicenseJsonData constructor initialization
        /// </summary>
        public LicenseJsonData()
        {
            LicenseList = new List<LicenseDetails>();
        }
        /// <summary>
        /// License List property holds the license details
        /// </summary> 
        public List<LicenseDetails> LicenseList { get; set; }
    }

    /// <summary>
    /// model to hold User LicenseDetails  .
    /// </summary>
    public class UserLicenseDetails
    {
        /// <summary>
        /// User id .
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// LicenseJsonData details
        /// </summary>
        public LicenseJsonData LicenseDetails { get; set; }


        /// <summary>
        /// UserLicenseDetails constructor initialization
        /// </summary>
        public UserLicenseDetails()
        {
            LicenseDetails = new LicenseJsonData();
        }
    }

    /// <summary>
    /// License details data model
    /// </summary>
    public class LicenseDetails
    {
        /// <summary>
        /// Construtcor
        /// </summary>
        public LicenseDetails()
        {
            Type = new LicenseType();
        }
        /// <summary>
        /// LicenseKey details
        /// </summary>
        public string LicenseKey { get; set; }

        /// <summary>
        /// license type details
        /// </summary>
        public LicenseType Type { get; set; }

        /// <summary>
        /// License key activation date
        /// </summary>
        public DateTime ActivationDate { get; set; }

        /// <summary>
        /// License key Expire Date property
        /// </summary>
        public DateTime ExpireDate { get; set; }
    }
}