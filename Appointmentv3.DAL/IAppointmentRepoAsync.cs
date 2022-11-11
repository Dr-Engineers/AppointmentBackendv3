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
    public interface IAppointmentRepoAsync
    {
        Task<List<Appointment>> getCardDetailsByDoctorIDAsync(int doctorID);
        Task<List<Appointment>> getCardDetailsByPetIDAsync(int petID);
        Task<List<Appointment>> getCardDetailsForBookingAsync(int doctorID, DateTime date);
        Task<List<Test>> getTestsAsync();
        Task CreateTestsAsync(string testName);
        Task<List<Clinic>> getClinicAsync();
        Task CreateClinicAsync(string clinicName);
        Task<List<Symptom>> getSymptomAsync();
        Task CreateSymptomAsync(string symptomName);
        Task<List<PetIssue>> getPetIssueAsync();
        Task CreatePetIssueAsync(string petIssueName);
        Task<List<Medicine>> getMedicineAsync();
        Task CreateMedicineAsync(string medicineName);
        Task<PetIssue> GetPetIssueByIdAsync(int id);
        Task<Appointment> getAppointmentAsync(int appointmentID);
        Task<Appointment> editAppointmentAsync(int appointmentID, Appointment editedAppointment);
        Task<Appointment> createAppointmentAsync(Appointment creatingAppointment);
    }
}
