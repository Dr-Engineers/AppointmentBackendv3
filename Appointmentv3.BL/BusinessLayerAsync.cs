using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.BL
{
    public class BusinessLayerAsync : IBusinessLayerAsync
    {
        IAppointmentRepoAsync repo = null;
        public BusinessLayerAsync(IAppointmentRepoAsync repo)
        {
            this.repo = repo;
        }

        public Task<Appointment> createAppointmentAsync(CreatingAppointmentDTO creatingAppointment)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> editAppointmentAsync(int appointmentID, Appointment editedAppointment)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> getAppointmentAsync(int appointmentID)
        {
            throw new NotImplementedException();
        }

        public Task<List<CardDetailsDTO>> getCardDetailsByDoctorIDAsync(int doctorID)
        {
            throw new NotImplementedException();
        }

        public Task<List<CardDetailsDTO>> getCardDetailsByPetIDAsync(int petID)
        {
            throw new NotImplementedException();
        }

        public Task<List<CardDetailsDTO>> getCardDetailsForBookingAsync(int doctorID, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<List<Clinic>> getClinicAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Medicine>> getMedicineAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<PetIssue>> getPetIssueAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Symptom>> getSymptomAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Test>> getTestsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
