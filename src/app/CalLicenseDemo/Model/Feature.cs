using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalLicenseDemo.Model
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        public string FeatureTitle { get; set; }
        public virtual ICollection<LicenseType> LicenseTypes { get; set; }
    }
}