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
        public AppointmentRepo(AppointmentDbContext db)
        {
            this.db = db;
        }

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

            db.Entry(editedAppointment).State = System.Data.Entity.EntityState.Modified;
            return editedAppointment;
        }

        public Appointment getAppointment(int appointmentID)
        {
            var appointmentById = db.Appointments.Find(appointmentID);
            if (appointmentById == null)
                return null;
            return appointmentById;
        }

        public CardDetailsDTO getCardDetailsByDoctorID(int doctorID)
        {
            var appointmentById = db.Appointments.Find(doctorID);
            if (appointmentById == null)
                return null;

            CardDetailsDTO CardDetail = new CardDetailsDTO();

            CardDetail.DoctorID = doctorID;
            CardDetail.PetID = appointmentById.PetID;
            CardDetail.AppointmentID = appointmentById.AppointmentID;
            CardDetail.AppointmentDate = appointmentById.AppointmentDate;
            CardDetail.AppointmentStatus = appointmentById.AppointmentStatus;

            return CardDetail;
        }

        public CardDetailsDTO getCardDetailsByPetID(int petID)
        {
            throw new NotImplementedException();
        }

        public CardDetailsDTO getCardDetailsForBooking(int doctorID, DateTime date)
        {
            throw new NotImplementedException();
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
