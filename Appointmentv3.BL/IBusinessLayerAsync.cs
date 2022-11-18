using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.BL
{
    public interface IBusinessLayerAsync
    {
        Task<List<CardDetailsDTO>> getCardDetailsByDoctorIDAsync(int doctorID);
        Task<List<CardDetailsDTO>> getCardDetailsByPetIDAsync(int petID);
        Task<List<CardDetailsDTO>> getCardDetailsForBookingAsync(int doctorID, DateTime date);
        Task<List<Test>> getTestsAsync();
        Task CreateTestAsync(string testName);
        Task<List<Clinic>> getClinicAsync();
        Task CreateClinicAsync(string clinicName);
        Task<List<Symptom>> getSymptomAsync();
        Task CreateSymptomAsync(string symptomName);
        Task<List<PetIssue>> getPetIssueAsync();
        Task CreatePetIssueAsync(string petIssue);
        Task<List<Medicine>> getMedicineAsync();
        Task CreateMedicineAsync(string medicineTest);
        Task<Appointment> getAppointmentAsync(int appointmentID);
        Task<Appointment> editAppointmentAsync(int appointmentID, Appointment editedAppointment, int h, int d, int m, int y);
        Task<Appointment> createAppointmentAsync(CreatingAppointmentDTO creatingAppointment, int h, int d, int m, int y);
    }
}
