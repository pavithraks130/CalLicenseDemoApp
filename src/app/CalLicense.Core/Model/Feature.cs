using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CalLicense.Core.Model
{
    /// <summary>
    /// Apllication feature list info
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// Feature Id
        /// </summary>
        [Key]
        public int FeatureId { get; set; }
        /// <summary>
        /// Feature title 
        /// </summary>
        public string FeatureTitle { get; set; }

        /// <summary>
        /// License type details collection.
        /// </summary>
        [JsonIgnore]
        public virtual  ICollection<LicenseType> LicenseTypes { get; set; }
    }
}