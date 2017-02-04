using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CalLicenseDemo.Model
{
    public class Feature
    {
        [Key]
        public int FeatureId { get; set; }

        public string FeatureTitle { get; set; }
        [JsonIgnore]
        public  ICollection<LicenseType> LicenseTypes { get; set; }
    }
}