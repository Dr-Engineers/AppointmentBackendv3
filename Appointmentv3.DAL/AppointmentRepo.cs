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
    public class AppointmentRepo : IAppointmentRepo
    {
        AppointmentDbContext db = new AppointmentDbContext();


        public Appointment createAppointment(Appointment creatingAppointment)
        {
            db.Appointments.Add(creatingAppointment);
            db.SaveChanges();
            return creatingAppointment;
        }

        public void CreateClinic(string clinicName)
        {
            db.Clinics.Add(new Clinic() { ClinicName = clinicName });
            db.SaveChanges();
        }

        public void CreateMedicine(string medicineName)
        {
            db.Medicines.Add(new Medicine() { MedicineName = medicineName });
            db.SaveChanges();
        }

        public void CreatePetIssue(string petIssueName)
        {
            db.PetIssues.Add(new PetIssue() { PetIssueName = petIssueName });
            db.SaveChanges();
        }

        public void CreateSymptom(string symptomName)
        {
            db.Symptoms.Add(new Symptom() { SymptomName = symptomName });
            db.SaveChanges();
        }

        public void CreateTest(string testName)
        {
            db.Tests.Add(new Test() { TestName = testName });
            db.SaveChanges();
        }

        public Appointment editAppointment(int appointmentID, Appointment editedAppointment)
        {
            var appt = db.Appointments.Find(appointmentID);

            if(appt == null)
                return null;

            //appt = editedAppointment;

            db.Entry(appt).CurrentValues.SetValues(editedAppointment);
            db.Entry(appt.VitalID).CurrentValues.SetValues(editedAppointment.VitalID);
            appt.ObservedPetIssues.Clear();
            db.Entry(appt).Collection(a => a.ObservedPetIssues).CurrentValue = editedAppointment.ObservedPetIssues;
            appt.Prescription.Clear();
            db.Entry(appt).Collection(a => a.Prescription).CurrentValue = editedAppointment.Prescription;
            appt.DiagnosedSymptoms.Clear();
            db.Entry(appt).Collection(a => a.DiagnosedSymptoms).CurrentValue = editedAppointment.DiagnosedSymptoms;
            appt.PrescribedTests.Clear();
            db.Entry(appt).Collection(a => a.PrescribedTests).CurrentValue = editedAppointment.PrescribedTests;
            appt.RecommendedDoctors.Clear();
            db.Entry(appt).Collection(a => a.RecommendedDoctors).CurrentValue = editedAppointment.RecommendedDoctors;
            appt.RecommendedClinics.Clear();
            db.Entry(appt).Collection(a => a.RecommendedClinics).CurrentValue = editedAppointment.RecommendedClinics;
            //db.Entry(appt).Collection(a => a.RecommendationID).CurrentValue = editedAppointment.RecommendationID;
            //db.Entry(appt.Prescription).State = System.Data.Entity.EntityState.Modified;
            //db.Entry(appt.DiagnosedSymptomID).State = System.Data.Entity.EntityState.Modified;
            //db.Entry(appt.PrescribedTestID).State = System.Data.Entity.EntityState.Modified;
            //db.Entry(appt.RecommendationID).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            db.Database.ExecuteSqlCommand("DELETE FROM ObservedPetIssues WHERE Appointment_AppointmentID IS NULL");
            db.Database.ExecuteSqlCommand("DELETE FROM Prescription WHERE Appointment_AppointmentID IS NULL");
            db.Database.ExecuteSqlCommand("DELETE FROM DiagnosedSymptoms WHERE Appointment_AppointmentID IS NULL");
            db.Database.ExecuteSqlCommand("DELETE FROM PrescribedTests WHERE Appointment_AppointmentID IS NULL");
            db.Database.ExecuteSqlCommand("DELETE FROM RecommendedDoctors WHERE Appointment_AppointmentID IS NULL");
            db.Database.ExecuteSqlCommand("DELETE FROM RecommendedClinics WHERE Appointment_AppointmentID IS NULL");
            return editedAppointment;
        }

        public Appointment getAppointment(int appointmentID)
        {
            var appointmentById = db.Appointments.Find(appointmentID);
            if (appointmentById == null)
                return null;
            return appointmentById;
        }

        public List<Appointment> getCardDetailsByDoctorID(int doctorID)
        {
            var appointmentByDocId = db.Appointments.Where(appt => appt.DoctorID == doctorID).ToList();

            if (appointmentByDocId == null)
                return null;
            return appointmentByDocId;        

        }

        public List<Appointment> getCardDetailsByPetID(int petID)
        {
            var appointmentByPetID = db.Appointments.Where(appt => appt.PetID == petID).ToList();
            if (appointmentByPetID == null)
                return null;
            return appointmentByPetID;
        }

        public List<Appointment> getCardDetailsForBooking(int doctorID, DateTime date)
        {
            var appointmentByPetID = db.Appointments.Where(appt => appt.DoctorID == doctorID && appt.AppointmentDate.Date.ToString("d") == date.Date.ToString("d")).ToList();
            if (appointmentByPetID == null)
                return null;
            return appointmentByPetID;
        }

        public List<Clinic> getClinic()
        {
            return db.Clinics.ToList();
        }

        public List<Medicine> getMedicine()
        {
            return db.Medicines.ToList();
        }

        public List<PetIssue> getPetIssue()
        {
            return db.PetIssues.ToList();
        }

        public PetIssue GetPetIssueById(int id)
        {
            return db.PetIssues.Where(issue => issue.PetIssueID == id).FirstOrDefault();
        }

        public List<Symptom> getSymptom()
        {
            return db.Symptoms.ToList();
        }

        public List<Test> getTests()
        {
            return db.Tests.ToList();
        }
    }
}
