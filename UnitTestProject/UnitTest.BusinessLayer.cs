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
        [TestMethod]
        public async Task TestEditAppointmentIfNotPresent()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            Appointment appt = new Appointment
            {
                DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Closed,
                Reason = "THIS IS TESTING"

            };

            mock.Setup(x => x.editAppointmentAsync(1, appt)).ReturnsAsync(new Appointment
            {
                DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"

            });

            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            try
            {
                var actual = await bl.editAppointmentAsync(21, appt);
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(404, (int)ex.GetHttpCode());
            }

        }


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
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
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
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"

            });

            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            try
            {
                var actual = await bl.getAppointmentAsync(12);
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(404, (int)ex.GetHttpCode());
            }
        }


        

        [TestMethod]
        public async Task TestGetAppointmentByDocIdIfNotPresent()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getCardDetailsByDoctorIDAsync(1)).ReturnsAsync(new List<Appointment>());
            var bl = new BusinessLayerAsync(mock.Object);
            try
            {
                var xyz = await bl.getCardDetailsByDoctorIDAsync(1);
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(404, (int)ex.GetHttpCode());
            }
        }


        [TestMethod]
        public async Task TestGetAppointmentByDocId()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getCardDetailsByDoctorIDAsync(2)).ReturnsAsync(new List<Appointment>()
            {
                 new Appointment()
                {
                    DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"
                },
                new Appointment()
                {
                    DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 2,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("11/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"
                }
            });

            var bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getCardDetailsByDoctorIDAsync(2);
            Assert.IsInstanceOfType(actual, typeof(List<CardDetailsDTO>));

        }

        [TestMethod]
        public async Task TestGetCardDetailsByPetIdAsyncIfNotPresent()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getCardDetailsByPetIDAsync(5)).ReturnsAsync(new List<Appointment>());
            var bl = new BusinessLayerAsync(mock.Object);
            try
            {
                var xyz = await bl.getCardDetailsByPetIDAsync(5);
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(404, (int)ex.GetHttpCode());
            }
        }

        [TestMethod]
        public async Task TestGetCardDetailsByPetIdAsync()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            mock.Setup(x => x.getCardDetailsByPetIDAsync(1)).ReturnsAsync(new List<Appointment>()
            {
                new Appointment()
                {
                    DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"
                },
                new Appointment()
                {
                    DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 2,
                PetID = 1,
                DoctorID = 3,
                AppointmentDate = Convert.ToDateTime("11/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"
                }
            });

            var bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getCardDetailsByPetIDAsync(1);
            Assert.IsInstanceOfType(actual, typeof(List<CardDetailsDTO>));
            
        }

        [TestMethod]
        public async Task TestgetCardDetailsForBookingAsync()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            DateTime dt = new DateTime();
            mock.Setup(x => x.getCardDetailsForBookingAsync(1, dt)).ReturnsAsync(new List<Appointment>()
            {
                 new Appointment()
                {
                    DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 1,
                PetID = 1,
                DoctorID = 2,
                AppointmentDate = Convert.ToDateTime("10/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"
                },
                new Appointment()
                {
                    DiagnosedSymptomID = new List<DiagnosedSymptom>(),
                ObservedPetIssueID = new List<ObservedPetIssue>(),
                PrescribedTestID = new List<PrescribedTest>(),
                Prescription = new List<PrescribedMedicine>(),
                RecommendedClinics = new List<RecommendedClinic>(),
                RecommendedDoctors = new List<RecommendedDoctor>(),
                VitalID = new Vital(),
                AppointmentID = 2,
                PetID = 1,
                DoctorID = 3,
                AppointmentDate = Convert.ToDateTime("11/11/2022"),
                AppointmentStatus = Status.Confirmed,
                Reason = "THIS IS TESTING"
                }
            });

            var bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getCardDetailsForBookingAsync(1, dt);
            Assert.IsInstanceOfType(actual, typeof(List<CardDetailsDTO>));
        }

        [TestMethod]
        public async Task TestGetCardDetailsForBookingIfNotPresent()
        {
            var mock = new Mock<IAppointmentRepoAsync>();
            DateTime dt = new DateTime();
            mock.Setup(x => x.getCardDetailsForBookingAsync(5, dt)).ReturnsAsync(new List<Appointment>());
            var bl = new BusinessLayerAsync(mock.Object);
            try
            {
                var xyz = await bl.getCardDetailsForBookingAsync(5, dt);
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(404, (int)ex.GetHttpCode());
            }
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
            } });

            IBusinessLayerAsync bl = new BusinessLayerAsync(mock.Object);
            var actual = await bl.getMedicineAsync();
            Assert.IsInstanceOfType(actual, typeof(List<Medicine>));
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