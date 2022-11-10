using Appointmentv3.BL;
using Appointmentv3.COMMON.Entities.Preset;
using Appointmentv3.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
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

            List<Clinic> expected = new List<Clinic>()
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
            };

            List<Clinic> actual = await bl.getClinicAsync();
            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void TestAppointmentsNotFoundWithDoctorID()
        {
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

            List<Medicine> expected = new List<Medicine>()
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
            };

            List<Medicine> actual = await bl.getMedicineAsync();
            Assert.AreEqual(expected, actual);

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

            List<Symptom> expected = new List<Symptom>()
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
            };

            List<Symptom> actual = await bl.getSymptomAsync();
            Assert.AreEqual(expected, actual);

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

            List<PetIssue> expected = new List<PetIssue>()
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
            };

            List<PetIssue> actual = await bl.getPetIssueAsync();
            Assert.AreEqual(expected, actual);

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

            List<Test> expected = new List<Test>()
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
            };

            List<Test> actual = await bl.getTestsAsync();
            Assert.AreEqual(expected, actual);

        }
    }
}
