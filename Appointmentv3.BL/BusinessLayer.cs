﻿using Appointmentv3.COMMON.DTO;
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

        public Appointment createAppointment(CreatingAppointmentDTO creatingAppointment)
        {
            if (creatingAppointment == null)
                return null;

            Appointment appointment = new Appointment();
            appointment.PetID = creatingAppointment.PetID;
            appointment.DoctorID = creatingAppointment.DoctorID;
            appointment.AppointmentDate = creatingAppointment.AppoitmentDate;
            foreach (var id in creatingAppointment.PetIssues)
            {
                PetIssue petIssue = this.repo.GetPetIssueById(id);
                ObservedPetIssue observedPetIssue = new ObservedPetIssue { PetIssue =  petIssue};
                appointment.ObservedPetIssueID.Add(observedPetIssue);
            }
            // Default values For the appointment
            appointment.AppointmentStatus = Status.Confirmed;
            appointment.RecommendationID = new List<Recommendation>();
            appointment.PrescribedTestID = new List<PrescribedTest>();
            appointment.Prescription = new List<PrescribedMedicine>();
            appointment.DiagnosedSymptomID = new List<DiagnosedSymptom>();
            appointment.VitalID = new Vital();
            appointment.Reason = null;

            var newAppointment = this.repo.createAppointment(appointment);

            //var petClient = new RestClient();
            //var doctorClient = new RestClient();

            //var petRequest = new RestRequest("api/petId/{petId}/appId/{appId}", Method.Put);
            //petRequest.AddUrlSegment("petId", newAppointment.PetID);
            //petRequest.AddUrlSegment("appId", newAppointment.AppointmentID);

            //var doctorRequest = new RestRequest("api/doctorId/{doctorId}/appId/{appId}", Method.Put);
            //doctorRequest.AddUrlSegment("doctorId", newAppointment.DoctorID);
            //doctorRequest.AddUrlSegment("appId", newAppointment.AppointmentID);

            //petClient.Execute(petRequest);
            //doctorClient.Execute(doctorRequest);

            return newAppointment;
        }

        public Appointment editAppointment(int appointmentID, Appointment editedAppointment)
        {
            return this.repo.editAppointment(appointmentID, editedAppointment);
        }

        public Appointment getAppointment(int appointmentID)
        {
            return this.repo.getAppointment(appointmentID);
        }

        public List<CardDetailsDTO> getCardDetailsByDoctorID(int doctorID)
        {
            throw new NotImplementedException();
        }

        public List<CardDetailsDTO> getCardDetailsByPetID(int petID)
        {
            throw new NotImplementedException();
        }

        public List<CardDetailsDTO> getCardDetailsForBooking(int doctorID, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Clinic> getClinic()
        {
            throw new NotImplementedException();
        }

        public List<Medicine> getMedicine()
        {
            return this.getMedicine();
        }

        public List<PetIssue> getPetIssue()
        {
            return this.getPetIssue();
        }

        public List<Symptom> getSymptom()
        {
            return this.getSymptom();
        }

        public List<Test> getTests()
        {
            throw new NotImplementedException();
        }
    }
}
