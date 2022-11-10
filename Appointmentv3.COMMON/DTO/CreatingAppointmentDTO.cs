using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.DTO
{
    public class CreatingAppointmentDTO
    {
        [Required]
        public int PetID { get; set; }
        [Required]
        public int DoctorID { get; set; }
        [Required]
        public DateTime AppoitmentDate { get; set; }
        public string Reason { get; set; }
        [Required]
        public List<int> PetIssues { get; set; }
    }
}
