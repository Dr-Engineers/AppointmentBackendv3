using Appointmentv3.COMMON.Entities.Preset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.Entities
{
    public class Recommendation
    {
        public int RecommendationID { get; set; }
        public virtual List<Clinic> RecommendedClinic { get; set; }
        public virtual List<Doctor> RecommendedDoctor { get; set; }
    }
}
