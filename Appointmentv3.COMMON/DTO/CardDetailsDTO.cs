using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.DTO
{
    public class CardDetailsDTO
    {
        public int AppointmentID { get; set; }
        public int PetID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Status AppointmentStatus { get; set; }
    }
}
