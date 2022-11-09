using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.DTO
{
    public class CreatingAppointmentDTO
    {
        public int PetID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppoitmentDate { get; set; }
        public string Reason { get; set; }
        public List<int> PetIssues { get; set; }
    }
}
