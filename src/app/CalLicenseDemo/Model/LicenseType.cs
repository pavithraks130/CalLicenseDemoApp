using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public ICollection<Feature> FeatureList { get; set; }

    }
}
