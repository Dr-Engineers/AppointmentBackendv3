﻿using Appointmentv3.COMMON.DTO;
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
        public async Task CreateClinicAsync(string clinicName)
        {
            db.Clinics.Add(new Clinic() { ClinicName = clinicName });
            await db.SaveChangesAsync();
        }

        public async Task CreateMedicineAsync(string medicineName)
        {
            db.Medicines.Add(new Medicine() { MedicineName = medicineName });
            await db.SaveChangesAsync();
        }

        public async Task CreatePetIssueAsync(string petIssueName)
        {
            db.PetIssues.Add(new PetIssue() { PetIssueName = petIssueName });
            await db.SaveChangesAsync();
        }

        public async Task CreateSymptomAsync(string symptomName)
        {
            db.Symptoms.Add(new Symptom() { SymptomName = symptomName });
            await db.SaveChangesAsync();
        }

        public async Task CreateTestAsync(string testName)
        {
            db.Tests.Add(new Test() { TestName = testName });
            await db.SaveChangesAsync();
        }
        public async Task<Appointment> editAppointmentAsync(int appointmentID, Appointment editedAppointment)
        {
            var appt = await db.Appointments.FindAsync(appointmentID);

            if (appt == null)
                return null;

            appt = editedAppointment;

            db.Entry(appt).CurrentValues.SetValues(editedAppointment);
            db.Entry(appt.VitalID).CurrentValues.SetValues(editedAppointment.VitalID);
            appt.ObservedPetIssueID.Clear();
            db.Entry(appt).Collection(a => a.ObservedPetIssueID).CurrentValue = editedAppointment.ObservedPetIssueID;
            appt.Prescription.Clear();
            db.Entry(appt).Collection(a => a.Prescription).CurrentValue = editedAppointment.Prescription;
            appt.DiagnosedSymptomID.Clear();
            db.Entry(appt).Collection(a => a.DiagnosedSymptomID).CurrentValue = editedAppointment.DiagnosedSymptomID;
            appt.PrescribedTestID.Clear();
            db.Entry(appt).Collection(a => a.PrescribedTestID).CurrentValue = editedAppointment.PrescribedTestID;
            appt.RecommendedDoctors.Clear();
            db.Entry(appt).Collection(a => a.RecommendedDoctors).CurrentValue = editedAppointment.RecommendedDoctors;
            appt.RecommendedClinics.Clear();
            db.Entry(appt).Collection(a => a.RecommendedClinics).CurrentValue = editedAppointment.RecommendedClinics;
            //db.Entry(appt).Collection(a => a.RecommendationID).CurrentValue = editedAppointment.RecommendationID;
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
