using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalLicense.Core.Model
{
    /// <summary>
    /// Model holds the user license details
    /// </summary>
    public class UserLicense
    {
        /// <summary>
        /// Constructor data intialization
        /// </summary>
        public UserLicense()
        {
            UserLicenseId = 0;
            UserKey = string.Empty;
            IsExpired = false;
            IsDeleted = false;
            ActivationDate = DateTime.MinValue;
        }
        /// <summary>
        /// UserLicense Id  property
        /// </summary>
        [Key]
        public int UserLicenseId { get; set; }
        /// <summary>
        /// user key property
        /// </summary>

        public string UserKey { get; set; }
        /// <summary>
        /// Expiry status
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        ///   User license remove status
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// User license activation date
        /// </summary>
        public DateTime ActivationDate { get; set; }

        /// <summary>
        ///user expiry date 
        /// </summary>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// License holder user id 
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// user LicenseId details
        /// </summary>
        public int LicenseId { get; set; }

        /// <summary>
        /// User details
        /// </summary>
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        /// <summary>
        /// user license 
        /// </summary>
        [ForeignKey("LicenseId")]
        public virtual License License { get; set; }
    }
}