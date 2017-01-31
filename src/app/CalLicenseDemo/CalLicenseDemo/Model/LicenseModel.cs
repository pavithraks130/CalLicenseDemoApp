using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CalLicenseDemo.Model
{

    public class LicenseType
    {
        public LicenseType()
        {
            TypeId = 0; TypeName = String.Empty; Description = String.Empty;
            ActiveDuration = 0;
        }
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int ActiveDuration { get; set; }
    }

    public class License
    {
        public License()
        {
            LicenseId=0; LicenseType = new LicenseType();
            LicenseKey = string.Empty;
            IsAvailable = false;
        }
        [Key]
        public int LicenseId { get; set; }
        public  string LicenseKey { get; set; }
        public bool IsAvailable { get; set; }
        public int LicenseTypeId { get; set; }
        [ForeignKey("LicenseTypeId")]
        public virtual LicenseType LicenseType { get; set; }

    }

    public class UserLicense
    {
        public UserLicense()
        {
            UserLicenseId = 0;
            UserKey = String.Empty;
            IsExpired = false;
            IsDeleted = false;
            ActivationDate = DateTime.MinValue;
            License = new License();
        }

        public int UserLicenseId { get; set; }
        public string UserKey { get; set; }
        public bool IsExpired { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime ActivationDate { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual  UserModel User { get; set; }
        public int LicenseId { get; set; }
        [ForeignKey("LicenseId")]
        public virtual License License { get; set; }
    }

}
