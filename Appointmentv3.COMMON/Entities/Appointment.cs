using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.Entities
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int PetID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Status AppointmentStatus { get; set; }
        public virtual List<ObservedPetIssue> ObservedPetIssueID { get; set; }
        public string Reason { get; set; }
        public virtual List<PrescribedMedicine> Prescription { get; set; }
        public virtual List<DiagnosedSymptom> DiagnosedSymptomID { get; set; }
        public virtual Vital VitalID { get; set; }
        public virtual List<PrescribedTest> PrescribedTestID { get; set; }
        public virtual List<Recommendation> RecommendationID { get; set; }
    }
}
