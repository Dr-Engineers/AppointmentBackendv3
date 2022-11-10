using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Appointmentv3.BL;
using Appointmentv3.COMMON.Entities;
using System.Collections.Generic;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.COMMON.DTO;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }


        [TestMethod]
        public void TestAppointmentsNotFoundWithDoctorID()
        {
        }

        [TestMethod]
        public void TestAppointmentAlreadySchedule()
        {
            //Appointmentv3.COMMON.Entities.Appointment Actual = new Appointmentv3.COMMON.Entities.Appointment();
            //List<ObservedPetIssue> issues = new List<ObservedPetIssue>();
            //List<PrescribedMedicine> PrescribedMedicines = new List<PrescribedMedicine>();
            //List<DiagnosedSymptom> DiagnosedSymptoms = new List<DiagnosedSymptom>();
            //List<PrescribedTest> PrescribedTests = new List<PrescribedTest>();
            //List<Recommendation> Recommendations = new List<Recommendation>();

            //for (int i = 0; i < 3; i++)
            //{
            //    ObservedPetIssue observedPetIssue = new ObservedPetIssue();
            //    observedPetIssue.ObservedPetIssueID = i;
            //    observedPetIssue.PetIssue.PetIssueID = i;
            //    observedPetIssue.PetIssue.PetIssueName = $"Leg Fracture + {i}";

            //    issues.Add(observedPetIssue);
            //}

            //for(int i = 0; i < 3; i++)
            //{
            //    PrescribedMedicine prescribedMedicine = new PrescribedMedicine();
            //    prescribedMedicine.PrescribedMedicineID = i;
            //    prescribedMedicine.Days = i;
            //    prescribedMedicine.Morning = true;
            //    prescribedMedicine.Afternoon = true;
            //    prescribedMedicine.Night = false;
            //    prescribedMedicine.BeforeFood = true;
            //    prescribedMedicine.Comments = $"Comment no {i}";

            //    prescribedMedicine.Medicine.MedicineID = i + 100;
            //    prescribedMedicine.Medicine.MedicineName = $"Medicine {i}";

            //    PrescribedMedicines.Add(prescribedMedicine);
            //}

            //for(int i = 0; i < 2; i++)
            //{
            //    DiagnosedSymptom diagnosedSymptom = new DiagnosedSymptom();
            //    diagnosedSymptom.DiagnosedSymptomID = i + 102;

            //}

            var appointment = new RestClient();





        }

        [TestMethod]
        public void TestGetCardDetailByPetId()
        {
            int petId = 10;
            IBusinessLayer reposit = new BusinessLayer();
            var expected = reposit.getCardDetailsByPetID(petId);


            List<CardDetailsDTO> actual = new List<CardDetailsDTO>();

            Assert.AreEqual(expected, null);
        }

        
    }
}
