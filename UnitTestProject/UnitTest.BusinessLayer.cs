using Appointmentv3.BL;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

using Appointmentv3.BL;
using Appointmentv3.COMMON.Entities;
using System.Collections.Generic;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.COMMON.DTO;

using System.Threading.Tasks;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestGetClinics()
        {

            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getClinicAsync()).ReturnsAsync(new List<Clinic>() 
            {   new Clinic()
                {
                    ClinicID = 1,
                    ClinicName = "clinicName1"
                },
                new Clinic()
                {
                    ClinicID = 2,
                    ClinicName = "clinicName2"
                } 
            });
            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getClinicAsync();
            Assert.IsInstanceOfType(actual, typeof(List<Clinic>));

        }

        [TestMethod]
        public async Task TestGetMedicines()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getMedicineAsync()).ReturnsAsync(new List<Medicine>()
            {   new Medicine()
                {
                    MedicineID = 1,
                    MedicineName = "MedicineName1"
                },
                new Medicine()
                {
                    MedicineID = 2,
                    MedicineName = "MedicineName2"
                }
            });
            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getMedicineAsync();
            Assert.IsInstanceOfType(actual, typeof(List<Medicine>));
        }

        [TestMethod]
        public async Task TestGetSymptoms()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getSymptomAsync()).ReturnsAsync(new List<Symptom>()
            {   new Symptom()
                {
                    SymptomID = 1,
                    SymptomName = "SymptomName1"
                },
                new Symptom()
                {
                    SymptomID = 2,
                    SymptomName = "SymptomName2"
                }
            });
            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getSymptomAsync();
            Assert.IsInstanceOfType(actual, typeof(List<Symptom>));
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

        [TestMethod]
        public async Task TestGetPetIssues()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getPetIssueAsync()).ReturnsAsync(new List<PetIssue>()
            {   new PetIssue()
                {
                    PetIssueID = 1,
                    PetIssueName = "PetIssueName1"
                },
                new PetIssue()
                {
                    PetIssueID = 2,
                    PetIssueName = "PetIssueName2"
                }
            });
            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getPetIssueAsync();
            Assert.IsInstanceOfType(actual, typeof(List<PetIssue>));
        }

        [TestMethod]
        public async Task TestGetTests()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getTestsAsync()).ReturnsAsync(new List<Test>()
            {   new Test()
                {
                    TestID = 1,
                    TestName = "TestName1"
                },
                new Test()
                {
                    TestID = 2,
                    TestName = "TestName2"
                }
            });
            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getTestsAsync();
            Assert.IsInstanceOfType(actual, typeof(List<Test>));
        }       
    }
}
