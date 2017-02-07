using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using CalLicenseDemo.Model;

namespace CalLicenseDemo.Common
{
    public class StringToListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var featureList = (ICollection<Feature>)value;
            if (featureList != null && featureList.Count > 0)
            {
                StringBuilder str = new StringBuilder();
                foreach (var feature in featureList)
                    str.Append(feature.FeatureTitle + ", ");
                return str.ToString().Remove(str.Length - 2);
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
