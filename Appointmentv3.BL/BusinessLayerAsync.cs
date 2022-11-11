using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.DAL;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Appointmentv3.BL
{
    public class BusinessLayerAsync : IBusinessLayerAsync
    {
        IAppointmentRepoAsync repo = null;
        public BusinessLayerAsync(IAppointmentRepoAsync repo)
        {
            this.repo = repo;
        }

        public async Task<Appointment> createAppointmentAsync(CreatingAppointmentDTO creatingAppointment)
        {
            if (creatingAppointment == null)
                return null;

            var TimeTable = await this.repo.getCardDetailsByPetIDAsync(creatingAppointment.PetID);
            foreach (var time in TimeTable)
            {
                if (time.AppointmentDate == creatingAppointment.AppoitmentDate)
                    throw new CannotBookAppointment("Your Pet already has an appointment at this selected time slot");
            }

            Appointment appointment = new Appointment();
            appointment.PetID = creatingAppointment.PetID;
            appointment.DoctorID = creatingAppointment.DoctorID;
            appointment.AppointmentDate = creatingAppointment.AppoitmentDate;
            appointment.Reason = creatingAppointment.Reason;
            appointment.ObservedPetIssueID = new List<ObservedPetIssue>();
            foreach (var id in creatingAppointment.PetIssues)
            {
                PetIssue petIssue = await this.repo.GetPetIssueByIdAsync(id);
                ObservedPetIssue observedPetIssue = new ObservedPetIssue { PetIssueID = petIssue.PetIssueID };
                appointment.ObservedPetIssueID.Add(observedPetIssue);
            }
            // Default values For the appointment
            appointment.AppointmentStatus = Status.Confirmed;
            //appointment.RecommendationID = new List<RecommendedClinic>();
            appointment.RecommendedDoctors = new List<RecommendedDoctor>();
            appointment.RecommendedClinics = new List<RecommendedClinic>();
            appointment.PrescribedTestID = new List<PrescribedTest>();
            appointment.Prescription = new List<PrescribedMedicine>();
            appointment.DiagnosedSymptomID = new List<DiagnosedSymptom>();
            appointment.VitalID = new Vital();

            var newAppointment = await this.repo.createAppointmentAsync(appointment);

            //var petClient = new RestClient();
            //var doctorClient = new RestClient();

            //var petRequest = new RestRequest("api/Pet/AddAppointment", Method.Put);
            //petRequest.AddJsonBody(new { petId = newAppointment.PetID, AppointmentId = newAppointment.AppointmentID });

            //var doctorRequest = new RestRequest("api/Doctors/AssignAppointmentToDoctor/{doctorId}", Method.Put);
            //doctorRequest.AddUrlSegment("doctorId", newAppointment.DoctorID);
            //doctorRequest.AddJsonBody(new { appointmentIdByAppointmentModule = newAppointment.AppointmentID });

            //petClient.Execute(petRequest);
            //doctorClient.Execute(doctorRequest);

            return newAppointment;
        }

        public async Task CreateClinicAsync(string clinicName)
        {
            await this.repo.CreateClinicAsync(clinicName);
        }

        public async Task CreateMedicineAsync(string medicineTest)
        {
            await this.repo.CreateMedicineAsync(medicineTest);
        }

        public async Task CreatePetIssueAsync(string petIssue)
        {
            await this.repo.CreatePetIssueAsync(petIssue);
        }

        public async Task CreateSymptomAsync(string symptomName)
        {
            await this.repo.CreatesymptomAsync(symptomName);
        }

        public async Task CreateTestAsync(string testName)
        {
            await this.CreateTestAsync(testName);
        }

        public async Task<Appointment> editAppointmentAsync(int appointmentID, Appointment editedAppointment)
        {
            return await this.repo.editAppointmentAsync(appointmentID, editedAppointment);
        }

        public async Task<Appointment> getAppointmentAsync(int appointmentID)
        {
            return await this.repo.getAppointmentAsync(appointmentID);
        }

        public async Task<List<CardDetailsDTO>> getCardDetailsByDoctorIDAsync(int doctorID)
        {
            var appointmentsByDocId = await this.repo.getCardDetailsByDoctorIDAsync(doctorID);

            if(appointmentsByDocId.Count == 0)
                throw new HttpException(404, $"No Appointment with Appointment ID: {doctorID}");

            List<CardDetailsDTO> CardDetails = new List<CardDetailsDTO>();
            foreach (var ApptId in appointmentsByDocId)
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

        public async Task<List<CardDetailsDTO>> getCardDetailsByPetIDAsync(int petID)
        {
            var appointmentsByPetID = await this.repo.getCardDetailsByPetIDAsync(petID);
            List<CardDetailsDTO> CardDetails = new List<CardDetailsDTO>();
            foreach (var ApptId in appointmentsByPetID)
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

        public async Task<List<CardDetailsDTO>> getCardDetailsForBookingAsync(int doctorID, DateTime date)
        {
            var appointmentsByDocAndDate = await this.repo.getCardDetailsForBookingAsync(doctorID, date);
            List<CardDetailsDTO> CardDetails = new List<CardDetailsDTO>();
            foreach (var ApptId in appointmentsByDocAndDate)
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
