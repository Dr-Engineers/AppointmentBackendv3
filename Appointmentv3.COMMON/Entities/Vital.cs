using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.Entities
{
    public class Vital
    {
        public int VitalID { get; set; }
        public int BPM { get; set; }
        public int Temp { get; set; }
        public int LungCapacity { get; set; }
    }
}
