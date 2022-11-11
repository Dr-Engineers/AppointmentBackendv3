using Appointmentv3.BL;
using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public async Task TestGetClinics()
        //{
        //    var mock = new Mock<IAppointmentRepoAsync>();
        //    mock.Setup(x => x.getClinicAsync()).ReturnsAsync(new List<Clinic>()
        //    {   new Clinic()
        //        {
        //            ClinicID = 1,
        //            ClinicName = "clinicName1"
        //        },
        //        new Clinic()
        //        {
        //            ClinicID = 2,
        //            ClinicName = "clinicName2"
        //        }
        //    });

        //    IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);

        //    List<Clinic> expected = new List<Clinic>()
        //    {   new Clinic()
        //        {
        //            ClinicID = 1,
        //            ClinicName = "clinicName1"
        //        },
        //        new Clinic()
        //        {
        //            ClinicID = 2,
        //            ClinicName = "clinicName2"
        //        }
        //    };

        //    // The AreEqual doesn't helps out in comparing the attribute by attribute. better compre the data type
        //    List<Clinic> actual = await bl.getClinicAsync();
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public async Task TestGetAppointmentAsync()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getAppointmentAsync(1)).ReturnsAsync(new Appointment
            {
                DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendationID = new List<Recommendation>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"

            });

            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);

            var actual = await bl.getAppointmentAsync(1);
            Assert.IsInstanceOfType(actual, typeof(Appointment));

        }


        [TestMethod]
        public async Task TestGetAppointmentAsyncIfNotPresent()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getAppointmentAsync(1)).ReturnsAsync(new Appointment
            {
                DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendationID = new List<Recommendation>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"

            });

            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);

            var actual = await bl.getAppointmentAsync(12);
            Assert.AreEqual(actual, null);
        }


        [TestMethod]
        public async Task TestEditAppointmentAsyncIfPresent()
        {
            // working on return type
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getAppointmentAsync(1)).ReturnsAsync(new Appointment
            {
                DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendationID = new List<Recommendation>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"

            });

            Appointment EditedAppointment = new Appointment()
            {
                DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendationID = new List<Recommendation>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING for edit"
            };


            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getClinicAsync();
            Assert.IsInstanceOfType(actual, typeof(List<Clinic>));
            var actual = await bl.editAppointmentAsync(1, EditedAppointment);
            Assert.IsInstanceOfType(actual, typeof(Appointment));
        }


        [TestMethod]
        public void TestGetAppointmentByDocIdIfNot()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getCardDetailsByDoctorIDAsync(1)).ReturnsAsync(new List<Appointment>());
            var bl = new BusinessLayerAsync(mock.Object);
            try
            {
              var xyz =  bl.getCardDetailsByDoctorIDAsync(1);
            } 
            catch(HttpException ex)
            {
                Assert.AreEqual(404, (int)ex.GetHttpCode());
            }
        }


        [TestMethod]
        public void TestGetAppointmentByDocId()
        {
            var mock = new Mock<IAppointmentRepoAsync>();

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
            List<CardDetailsDTO> list = new List<CardDetailsDTO>()
            { new CardDetailsDTO()
                {
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate =  Convert.ToDateTime("11/11/2022"),
                AppointmentStatus = Status.Confirmed
                },
                new Medicine()
            new CardDetailsDTO()
                {
                    MedicineID = 2,
                    MedicineName = "MedicineName2"
                AppointmentID = 3,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate =  Convert.ToDateTime("10/11/2022") ,
                AppointmentStatus = Status.Closed
                }
            });
            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getMedicineAsync();
            Assert.IsInstanceOfType(actual, typeof(List<Medicine>));
        }
            };
            int docId = 2;
            mock.Setup(x => x.getCardDetailsByDoctorIDAsync(1)).ReturnsAsync(new List<Appointment>());
            //mock.Setup(x => x.getCardDetailsByDoctorIDAsync(docId)).ReturnsAsync(list);


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
            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = bl.getCardDetailsByDoctorIDAsync(2);
            Assert.IsInstanceOfType(actual, typeof(List<CardDetailsDTO>));
            return Task.CompletedTask;
        }



        //[TestMethod]
        //public async Task TestAppointmentDataAsyncV2()
        //{
        //    var mockObj = new Mock<IAppointmentRepoAsync>();
        //    mockObj.Setup(x => x.getAppointmentAsync(1)).ReturnsAsync( new Appointment
        //    {

        //    });
        //}



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
        public async Task TestAppointmentAlreadySchedule()
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

            //for (int i = 0; i < 2; i++)
            //{
            //    DiagnosedSymptom diagnosedSymptom = new DiagnosedSymptom();
            //    diagnosedSymptom.DiagnosedSymptomID = i + 102;

            //}

        }

        
    }
}
