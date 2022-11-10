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

        public async Task<List<Appointment>> getCardDetailsByDoctorIDAsync(int doctorID)
        {
            var appointmentsByDocId = await (db.Appointments.Where(appt => appt.DoctorID == doctorID)).ToListAsync();
            if (appointmentsByDocId == null)
                return null;
            return appointmentsByDocId;   

        }

        public async Task<List<Appointment>> getCardDetailsByPetIDAsync(int petID)
        {
            var appointmentsByPetID = await (db.Appointments.Where(appt => appt.PetID == petID)).ToListAsync();
            if (appointmentsByPetID == null)
                return null;
            return appointmentsByPetID;
        }

            public async Task<List<Appointment>> getCardDetailsForBookingAsync(int doctorID, DateTime date)
        {
            var appointmentsByDocAndDate = await (db.Appointments.Where(appt => appt.DoctorID == doctorID && appt.AppointmentDate == date)).ToListAsync();
            if (appointmentsByDocAndDate == null)
                return null;
            return appointmentsByDocAndDate;
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

        public PetIssue GetPetIssueByIdAsync(int id)
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
