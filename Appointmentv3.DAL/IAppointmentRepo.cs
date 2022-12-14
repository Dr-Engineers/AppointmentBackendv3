using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.DAL
{
    public interface IAppointmentRepo
    {
        List<Appointment> getCardDetailsByDoctorID(int doctorID);
        List<Appointment> getCardDetailsByPetID(int petID);
        List<Appointment> getCardDetailsForBooking(int doctorID, DateTime date);
        List<Test> getTests();
        void CreateTest(string testName);
        List<Clinic> getClinic();
        void CreateClinic(string clinicName);
        List<Symptom> getSymptom();
        void CreateSymptom(string symptomName);
        List<PetIssue> getPetIssue();
        void CreatePetIssue(string petIssueName);
        List<Medicine> getMedicine();
        void CreateMedicine(string medicineName);
        PetIssue GetPetIssueById(int id);
        Appointment getAppointment(int appointmentID);
        Appointment editAppointment(int appointmentID, Appointment editedAppointment);
        Appointment createAppointment(Appointment creatingAppointment);
    }
}
