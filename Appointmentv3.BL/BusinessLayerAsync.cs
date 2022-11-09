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

        public async Task<List<Clinic>> getClinicAsync()
        {
           // var clinics = this.repo.getClinicAsync();
           //return clinics.GetAwaiter().GetResult();
            return await this.repo.getClinicAsync();
        }

        public async Task<List<Medicine>> getMedicineAsync()
        {
            return await this.repo.getMedicineAsync();
        }

        public async Task<List<PetIssue>> getPetIssueAsync()
        {
            return await this.repo.getPetIssueAsync();
        }

        public async Task<List<Symptom>> getSymptomAsync()
        {
            return await this.repo.getSymptomAsync();
        }

        public async Task<List<Test>> getTestsAsync()
        {
            return await this.repo.getTestsAsync();
        }
    }
}
