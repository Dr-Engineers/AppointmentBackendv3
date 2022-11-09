using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.BL
{
    public interface IBusinessLayer
    {
        List<CardDetailsDTO> getCardDetailsByDoctorID(int doctorID);
        List<CardDetailsDTO> getCardDetailsByPetID(int petID);
        List<CardDetailsDTO> getCardDetailsForBooking(int doctorID, DateTime date);
        List<Test> getTests();
        List<Clinic> getClinic();
        List<Symptom> getSymptom();
        List<PetIssue> getPetIssue();
        List<Medicine> getMedicine();
        Appointment getAppointment(int appointmentID);
        Appointment editAppointment(int appointmentID, Appointment editedAppointment);
        Appointment createAppointment(CreatingAppointmentDTO creatingAppointment);
    }
}
