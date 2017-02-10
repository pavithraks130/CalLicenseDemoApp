using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalLicense.Core.Model
{
    /// <summary>
    /// License details
    /// </summary>
    public  class License
    {
        /// <summary>
        /// data initialization
        /// </summary>
        public License()
        {
            LicenseId = 0;
            LicenseKey = string.Empty;
            IsAvailable = false;
        }

        /// <summary>
        /// License id property
        /// </summary>
        [Key]
        public int LicenseId { get; set; }

        /// <summary>
        /// License key property
        /// </summary>
        public string LicenseKey { get; set; }
        /// <summary>
        /// License key status property
        /// </summary>
        public bool IsAvailable { get; set; }
        /// <summary>
        /// License type id property
        /// </summary>
        public  int LicenseTypeId { get; set; }

        /// <summary>
        /// License type details property
        /// </summary>
        [ForeignKey("LicenseTypeId")]
        public virtual LicenseType LicenseType { get; set; }
    }
}