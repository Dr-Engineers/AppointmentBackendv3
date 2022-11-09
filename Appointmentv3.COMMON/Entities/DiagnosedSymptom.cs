using Appointmentv3.COMMON.Entities.Preset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.Entities
{
    public class DiagnosedSymptom
    {
        public int DiagnosedSymptomID { get; set; }
        public Symptom Symptom { get; set; }
    }
}
