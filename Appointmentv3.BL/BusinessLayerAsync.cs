﻿using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.BL
{
    public class BusinessLayerAsync : IBusinessLayerAsync
    {
        IAppointmentRepoAsync repo = null;
        public BusinessLayerAsync(IAppointmentRepoAsync repo)
        {
            this.repo = repo;
        }

        public Task<Appointment> createAppointmentAsync(CreatingAppointmentDTO creatingAppointment)
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

        public async Task<List<CardDetailsDTO>> getCardDetailsByDoctorIDAsync(int doctorID)
        {
            var appointmentsByDocId = await this.repo.getCardDetailsByDoctorIDAsync(doctorID);
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
