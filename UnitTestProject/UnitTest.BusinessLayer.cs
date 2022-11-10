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
    }
}
