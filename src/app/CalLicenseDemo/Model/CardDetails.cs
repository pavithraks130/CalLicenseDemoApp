using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalLicenseDemo.Model
{
    public class CardDetails
    {
        public CardDetails()
        {

        }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Month { get; set; }
        public short Years { get; set; }
        public short CVVNum { get; set; }
    }
}
