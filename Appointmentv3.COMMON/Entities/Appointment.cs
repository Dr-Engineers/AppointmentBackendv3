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
        public List<ObservedPetIssue> ObservedPetIssueID { get; set; }
        public string Reason { get; set; }
        public List<PrescribedMedicine> Prescription { get; set; }
        public List<DiagnosedSymptom> DiagnosedSymptomID { get; set; }
        public Vital VitalID { get; set; }
        public List<PrescribedTest> PrescribedTestID { get; set; }
        public List<Recommendation> RecommendationID { get; set; }
    }
}
