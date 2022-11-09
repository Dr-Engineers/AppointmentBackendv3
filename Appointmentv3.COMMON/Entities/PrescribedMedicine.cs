using Appointmentv3.COMMON.Entities.Preset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.Entities
{
    public class PrescribedMedicine
    {
        public int PrescribedMedicineID { get; set; }
        public Medicine Medicine { get; set; }
        public int Days { get; set; }
        public bool Morning { get; set; }
        public bool Afternoon { get; set; }
        public bool Night { get; set; }
        public bool BeforeFood { get; set; }
        public string Comments { get; set; }

    }
}
