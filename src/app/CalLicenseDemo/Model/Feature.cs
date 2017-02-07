using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CalLicenseDemo.Model
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }
        public string FeatureTitle { get; set; }

        [JsonIgnore]
        public virtual  ICollection<LicenseType> LicenseTypes { get; set; }
    }
}