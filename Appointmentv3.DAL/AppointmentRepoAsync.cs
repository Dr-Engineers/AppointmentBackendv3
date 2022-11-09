using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using Appointmentv3.COMMON.Entities.Preset;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.DAL
{
    public class AppointmentRepoAsync : IAppointmentRepoAsync
    {
        AppointmentDbContext db = new AppointmentDbContext();
        public Task<Appointment> createAppointmentAsync(Appointment creatingAppointment)
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

        public Task<List<Appointment>> getCardDetailsByDoctorIDAsync(int doctorID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> getCardDetailsByPetIDAsync(int petID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Appointment>> getCardDetailsForBookingAsync(int doctorID, DateTime date)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Clinic>> getClinicAsync()
        {
            var clinics = await db.Clinics.ToListAsync();
            return clinics;
            
        }

        public async Task<List<Medicine>> getMedicineAsync()
        {
            var medicines=await db.Medicines.ToListAsync();
            return medicines;
        }

        public async Task<List<PetIssue>> getPetIssueAsync()
        {
            var petIssues = await db.PetIssues.ToListAsync();
            return petIssues;
        }

        public PetIssue GetPetIssueByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Symptom>> getSymptomAsync()
        {
            var symptom = await db.Symptoms.ToListAsync();
            return symptom;
        }

        public async Task<List<Test>> getTestsAsync()
        {
            var tests= await db.Tests.ToListAsync();
            return tests;
        }
    }
}
