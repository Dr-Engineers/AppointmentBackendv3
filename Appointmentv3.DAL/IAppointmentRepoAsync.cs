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
        Task<List<CardDetailsDTO>> getCardDetailsByDoctorIDAsync(int doctorID);
        Task<List<CardDetailsDTO>> getCardDetailsByPetIDAsync(int petID);
        Task<List<CardDetailsDTO>> getCardDetailsForBookingAsync(int doctorID, DateTime date);
        Task<List<Test>> getTestsAsync();
        Task<List<Clinic>> getClinicAsync();
        Task<List<Symptom>> getSymptomAsync();
        Task<List<PetIssue>> getPetIssueAsync();
        PetIssue GetPetIssueByIdAsync(int id);
        Task<List<Medicine>> getMedicineAsync();
        Task<Appointment> getAppointmentAsync(int appointmentID);
        Task<Appointment> editAppointmentAsync(int appointmentID, Appointment editedAppointment);
        Task<Appointment> createAppointmentAsync(Appointment creatingAppointment);
    }
}
