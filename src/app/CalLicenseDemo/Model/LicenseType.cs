using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalLicenseDemo.Model
{
    public class LicenseType
    {
        public LicenseType()
        {
            TypeId = 0;
            TypeName = string.Empty;
            Description = string.Empty;
            ActiveDuration = 0;
        }

        [Key]
        public int TypeId { get; set; }

        public string TypeName { get; set; }
        public string Description { get; set; }
        public int ActiveDuration { get; set; }

        public  string ImageUrl { get; set; }

        public double Price { get; set; }
        public ICollection<Feature> FeatureList { get; set; }
    }
}