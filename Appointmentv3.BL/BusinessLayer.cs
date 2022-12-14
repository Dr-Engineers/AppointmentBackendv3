using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointmentv3.DAL;
using RestSharp;

namespace Appointmentv3.BL
{
    public class BusinessLayer : IBusinessLayer
    {
        IAppointmentRepo repo = null;
        public BusinessLayer(IAppointmentRepo repo)
        {
            this.repo = repo;
        }

        public Appointment createAppointment(CreatingAppointmentDTO creatingAppointment, int h, int d, int m, int y)
        {
            if (creatingAppointment == null)
                return null;

            var TimeTable = this.repo.getCardDetailsByPetID(creatingAppointment.PetID);
            foreach (var time in TimeTable)
            {
                if (time.AppointmentDate == creatingAppointment.AppoitmentDate)
                    throw new CannotBookAppointment("Your Pet already has an appointment at this selected time slot");
            }

            Appointment appointment = new Appointment();
            appointment.PetID = creatingAppointment.PetID;
            appointment.DoctorID = creatingAppointment.DoctorID;
            appointment.AppointmentDate = new DateTime(y, m, d, h, 0, 0);
            appointment.Reason = creatingAppointment.Reason;
            appointment.ObservedPetIssues = new List<ObservedPetIssue>();
            foreach (var id in creatingAppointment.PetIssues)
            {
                PetIssue petIssue = this.repo.GetPetIssueById(id);
                ObservedPetIssue observedPetIssue = new ObservedPetIssue { PetIssueID =  petIssue.PetIssueID};
                appointment.ObservedPetIssues.Add(observedPetIssue);
            }
            // Default values For the appointment
            appointment.AppointmentStatus = Status.Confirmed;
            //appointment.RecommendationID = new List<RecommendedClinic>();
            appointment.RecommendedDoctors = new List<RecommendedDoctor>();
            appointment.RecommendedClinics = new List<RecommendedClinic>();
            appointment.PrescribedTests = new List<PrescribedTest>();
            appointment.Prescription = new List<PrescribedMedicine>();
            appointment.DiagnosedSymptoms = new List<DiagnosedSymptom>();
            appointment.VitalID = new Vital();
            appointment.Comments = "";
            
            var newAppointment = this.repo.createAppointment(appointment);

            //var petClient = new RestClient();
            //var doctorClient = new RestClient();

            //var petRequest = new RestRequest("https://petzeypetapi20221112164250.azurewebsites.net/api/Pet/AddAppointment", Method.Post);
            //petRequest.AddJsonBody(new { petId = newAppointment.PetID, AppointmentId = newAppointment.AppointmentID });

            //var doctorRequest = new RestRequest($"https://apilayervet20221112172346.azurewebsites.net/api/Doctors/AssignAppointmentToDoctor/{newAppointment.DoctorID}", Method.Post);
            //doctorRequest.AddJsonBody(new { appointmentIdByAppointmentModule = newAppointment.AppointmentID });

            //petClient.Execute(petRequest);
            //doctorClient.Execute(doctorRequest);

            return newAppointment;
        }

        public void CreateClinc(string clinicName)
        {
            this.repo.CreateClinic(clinicName);
        }

        public void CreateMedicine(string medicineName)
        {
            this.repo.CreateMedicine(medicineName);
        }

        public void CreatePetIssue(string petIssueName)
        {
            this.repo.CreatePetIssue(petIssueName);
        }

        public void CreateSymptom(string symptomName)
        {
            this.repo.CreateSymptom(symptomName);
        }

        public void CreateTest(string testName)
        {
            this.repo.CreateTest(testName);
        }

        public Appointment editAppointment(int appointmentID, Appointment editedAppointment, int h, int d, int m, int y)
        {
            editedAppointment.AppointmentDate = new DateTime(y, m, d, h, 0, 0);
            return this.repo.editAppointment(appointmentID, editedAppointment);
        }

        public Appointment getAppointment(int appointmentID)
        {
            var res = this.repo.getAppointment(appointmentID);
            if (res == null)
                return null;
            return res;
        }

        public List<CardDetailsDTO> getCardDetailsByDoctorID(int doctorID)
        {
            var appointmentByDocId =  this.repo.getCardDetailsByDoctorID(doctorID);
            List<CardDetailsDTO> CardDetails = new List<CardDetailsDTO>();
            foreach (var ApptId in appointmentByDocId)
            {
                CardDetailsDTO CardDetail = new CardDetailsDTO();

                CardDetail.DoctorID = ApptId.DoctorID;
                CardDetail.PetID = ApptId.PetID;
                CardDetail.AppointmentID = ApptId.AppointmentID;
                CardDetail.AppointmentDate = ApptId.AppointmentDate;
                CardDetail.AppointmentStatus = ApptId.AppointmentStatus;

                CardDetails.Add(CardDetail);
            }
            return CardDetails;
        }

        public List<CardDetailsDTO> getCardDetailsByPetID(int petID)
        {
            var appointmentByPetID =  this.repo.getCardDetailsByPetID(petID);
            List<CardDetailsDTO> CardDetails = new List<CardDetailsDTO>();
            foreach (var ApptId in appointmentByPetID)
            {
                CardDetailsDTO cardDetails = new CardDetailsDTO();
                cardDetails.DoctorID = ApptId.DoctorID;
                cardDetails.PetID = ApptId.PetID;
                cardDetails.AppointmentID = ApptId.AppointmentID;
                cardDetails.AppointmentDate = ApptId.AppointmentDate;
                cardDetails.AppointmentStatus = ApptId.AppointmentStatus;

                CardDetails.Add(cardDetails);
            }
            return CardDetails;
        }

        public List<CardDetailsDTO> getCardDetailsForBooking(int doctorID, DateTime date)
        {
            var appointmentbyDetailsForBooking =  this.repo.getCardDetailsForBooking(doctorID, date);
            List<CardDetailsDTO> CardDetails = new List<CardDetailsDTO>();
            foreach (var ApptId in appointmentbyDetailsForBooking)
            {
                CardDetailsDTO cardDetails = new CardDetailsDTO();
                cardDetails.DoctorID = ApptId.DoctorID;
                cardDetails.PetID = ApptId.PetID;
                cardDetails.AppointmentID = ApptId.AppointmentID;
                cardDetails.AppointmentDate = ApptId.AppointmentDate;
                cardDetails.AppointmentStatus = ApptId.AppointmentStatus;

                CardDetails.Add(cardDetails);
            }
            return CardDetails;
        }

        public List<Clinic> getClinic()
        {
            return this.repo.getClinic();
        }

        public List<Medicine> getMedicine()
        {
            return this.repo.getMedicine();
        }

        public List<PetIssue> getPetIssue()
        {
            return this.repo.getPetIssue();
        }

        public List<Symptom> getSymptom()
        {
            return this.repo.getSymptom();
        }

        public List<Test> getTests()
        {
            return this.repo.getTests();
        }
    }
}
