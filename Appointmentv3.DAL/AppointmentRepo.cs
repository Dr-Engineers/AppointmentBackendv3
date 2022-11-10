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

        public Appointment editAppointment(int appointmentID, Appointment editedAppointment)
        {
            var appt = db.Appointments.Find(appointmentID);

            if(appt == null)
                return null;

            appt = editedAppointment;

            db.Entry(appt).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.ObservedPetIssueID).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.Prescription).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.DiagnosedSymptomID).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.PrescribedTestID).State = System.Data.Entity.EntityState.Modified;
            db.Entry(appt.RecommendationID).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
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
            var appointmentByPetID = db.Appointments.Where(appt => appt.DoctorID == doctorID && appt.AppointmentDate == date).ToList();
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
