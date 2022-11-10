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
        public async Task<Appointment> createAppointmentAsync(Appointment creatingAppointment)
        {
            db.Appointments.Add(creatingAppointment);
            await db.SaveChangesAsync();
            return creatingAppointment;
        }

        public async Task<Appointment> editAppointmentAsync(int appointmentID, Appointment editedAppointment)
        {
            var appt = await db.Appointments.FindAsync(appointmentID);

            if (appt == null)
                return null;

            appt = editedAppointment;

            db.Entry(appt).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.ObservedPetIssueID).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.Prescription).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.DiagnosedSymptomID).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.PrescribedTestID).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.RecommendationID).State = System.Data.Entity.EntityState.Modified;
            await db.SaveChangesAsync();
            return editedAppointment;
        }

        public async Task<Appointment> getAppointmentAsync(int appointmentID)
        {
            var appointmentById = await db.Appointments.FindAsync(appointmentID);
            if (appointmentById == null)
                return null;
            return appointmentById;
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

        public async Task<PetIssue> GetPetIssueByIdAsync(int id)
        {
            return await db.PetIssues.Where(issue => issue.PetIssueID == id).FirstOrDefaultAsync();
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
