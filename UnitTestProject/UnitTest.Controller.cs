using Appointmentv3.API.Controllers;
using Appointmentv3.BL;
using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using Appointmentv3.COMMON.Entities.Preset;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for UnitTest
    /// </summary>
    [TestClass]
    public class UnitTest
    {
        public UnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestGetAppointmentDetailsFound()
        {
            //arrange
            var appointment = new Appointment();
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.getAppointmentAsync(2)).ReturnsAsync(appointment);  
            var controller = new AppointmentAsyncController(mockBL.Object);

            //act
            var mockResult = controller.GetAppointmentDetails(2);

            //assert
            Assert.IsInstanceOfType(mockResult, typeof(Task<IHttpActionResult>));
        }

        [TestMethod]
        public void TestGetAppointmentDetailsThrowsException()
        {
            //arrange
            Appointment appointment = null;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.getAppointmentAsync(2)).Throws(new HttpException(404, "Appointment not created"));
            var controller = new AppointmentAsyncController(mockBL.Object);

            try
            {
                //act
                var mockResult = controller.GetAppointmentDetails(2);
            }

            catch (HttpException ex)
            {
                // HttpException is expected
                Assert.AreEqual(404, (int)ex.GetHttpCode());
                //Assert.AreEqual("Not authorized.", ex.Message);
            }
            catch (Exception)
            {
                // Any other exception should cause the test to fail
                Assert.Fail();
            }

            //assert
            //Assert.IsInstanceOfType(mockResult, typeof(Task<IHttpActionResult>));


        }

        [TestMethod]
        public void TestPostAppointmentDetailsFound()
        {
            //arrange
            var newAppointment = new CreatingAppointmentDTO();
            var appointment = new Appointment();
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.createAppointmentAsync(newAppointment)).ReturnsAsync(appointment);
            var controller = new AppointmentAsyncController(mockBL.Object);

            //act
            var mockResult = controller.PostAppointment(newAppointment);

            //assert
            Assert.IsInstanceOfType(mockResult, typeof(Task<IHttpActionResult>));


        }

        [TestMethod]
        public void TestPostAppointmentDetailsThrowsException()
        {
            //arrange
            CreatingAppointmentDTO newAppointment = new CreatingAppointmentDTO();
            Appointment appointment = null;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.createAppointmentAsync(newAppointment)).Throws(new HttpException(400, "All fields not filled"));
            var controller = new AppointmentAsyncController(mockBL.Object);

            try
            {
                //act
                var mockResult = controller.PostAppointment(newAppointment);
            }

            catch (HttpException ex)
            {
                // HttpException is expected
                Assert.AreEqual(400, (int)ex.GetHttpCode());
                //Assert.AreEqual("Not authorized.", ex.Message);
            }
            catch (Exception)
            {
                // Any other exception should cause the test to fail
                Assert.Fail();
            }

            //assert
            //Assert.IsInstanceOfType(mockResult, typeof(Task<IHttpActionResult>));


        }

        [TestMethod]
        public void TestEditAppointmentDetailsFound()
        {
            //arrange
            int appId = 1;
            var editedAppointment = new Appointment();
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.editAppointmentAsync(appId, editedAppointment));
            var controller = new AppointmentAsyncController(mockBL.Object);

            //act
            var mockResult = controller.editAppointment(appId, editedAppointment);

            //assert
            Assert.IsInstanceOfType(mockResult, typeof(Task<IHttpActionResult>));


        }

        [TestMethod]
        public void TestEditAppointmentDetailsThrowsException()
        {
            //arrange
            int appId = 0;
            Appointment editedAppointment = null;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.editAppointmentAsync(appId, editedAppointment)).Throws(new HttpException(400, "All fields not filled"));
            var controller = new AppointmentAsyncController(mockBL.Object);

            try
            {
                //act
                var mockResult = controller.editAppointment(appId, editedAppointment);
            }

            catch (HttpException ex)
            {
                // HttpException is expected
                Assert.AreEqual(400, (int)ex.GetHttpCode());
                //Assert.AreEqual("Not authorized.", ex.Message);
            }
            catch (Exception)
            {
                // Any other exception should cause the test to fail
                Assert.Fail();
            }

            //assert
            //Assert.IsInstanceOfType(mockResult, typeof(Task<IHttpActionResult>));
        }

        [TestMethod]
        public void TestGetCardDetailsByDoctorIDFound()
        {

            //arrange
            CardDetailsDTO cardDetailsDTO = new CardDetailsDTO();
            List<CardDetailsDTO> list = new List<CardDetailsDTO>();
            list.Add(cardDetailsDTO);   
            int docId = 1;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.getCardDetailsByDoctorIDAsync(docId)).ReturnsAsync(list);
            var controller = new AppointmentCardAsyncController(mockBL.Object);

            //act
            var mockResult = controller.getCardDetailsByDoctorID(docId);

            //assert
            Assert.AreNotEqual(mockResult.Result.Count(), 0);

        }

        [TestMethod]
        public void TestGetCardDetailsByDoctorIDNotFound()
        {
            //arrange
            CardDetailsDTO cardDetailsDTO = new CardDetailsDTO();
            List<CardDetailsDTO> list = new List<CardDetailsDTO>();
            int docId = 2;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.getCardDetailsByDoctorIDAsync(docId)).ReturnsAsync(() => list); 
            var controller = new AppointmentCardAsyncController(mockBL.Object);

            try
            {
                //act
                var mockResult = controller.getCardDetailsByDoctorID(docId); ;
            }

            catch (HttpException ex)
            {
                // HttpException is expected
                Assert.AreEqual(400, (int)ex.GetHttpCode());
                //Assert.AreEqual("Not authorized.", ex.Message);
            }
            catch (Exception)
            {
                // Any other exception should cause the test to fail
                Assert.Fail();
            }

        }

        [TestMethod]
        public void TestGetCardDetailsByPetIDFound()
        {

            //arrange
            CardDetailsDTO cardDetailsDTO = new CardDetailsDTO();
            List<CardDetailsDTO> list = new List<CardDetailsDTO>();
            list.Add(cardDetailsDTO);
            int petId = 1;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.getCardDetailsByPetIDAsync(petId)).ReturnsAsync(list);
            var controller = new AppointmentCardAsyncController(mockBL.Object);

            //act
            var mockResult = controller.getCardDetailsByPetID(petId);

            //assert
            Assert.AreNotEqual(mockResult.Result.Count(), 0);

        }

        [TestMethod]
        public void TestPetCardDetailsByDoctorIDNotFound()
        {
            //arrange
            CardDetailsDTO cardDetailsDTO = new CardDetailsDTO();
            List<CardDetailsDTO> list = new List<CardDetailsDTO>();
            int petId = 2;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.getCardDetailsByDoctorIDAsync(petId)).ReturnsAsync(list);
            var controller = new AppointmentCardAsyncController(mockBL.Object);

            try
            {
                //act
                var mockResult = controller.getCardDetailsByPetID(petId); ;
            }

            catch (HttpException ex)
            {
                // HttpException is expected
                Assert.AreEqual(400, (int)ex.GetHttpCode());
                //Assert.AreEqual("Not authorized.", ex.Message);
            }
            catch (Exception)
            {
                // Any other exception should cause the test to fail
                Assert.Fail();
            }

        }


        [TestMethod]
        public void TestGetCardDetailsForBookingFound()
        {

            //arrange
            CardDetailsDTO cardDetailsDTO = new CardDetailsDTO();
            List<CardDetailsDTO> list = new List<CardDetailsDTO>();
            list.Add(cardDetailsDTO);
            int docId = 1;
            DateTime date = DateTime.Now;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.getCardDetailsForBookingAsync(docId, date)).ReturnsAsync(list);
            var controller = new AppointmentCardAsyncController(mockBL.Object);

            //act
            var mockResult = controller.getCardDetailsForBooking(docId, date);

            //assert
            Assert.AreNotEqual(mockResult.Result.Count(), 0);

        }

        [TestMethod]
        public void TestGetCardDetailsForBookingThrowException()
        {
            //arrange
            CardDetailsDTO cardDetailsDTO = new CardDetailsDTO();
            List<CardDetailsDTO> list = new List<CardDetailsDTO>();
            int docId = 1;
            DateTime date = DateTime.Now;
            var mockBL = new Mock<IBusinessLayerAsync>();
            mockBL.Setup(x => x.getCardDetailsForBookingAsync(docId, date)).ReturnsAsync(list);
            var controller = new AppointmentCardAsyncController(mockBL.Object);

            try
            {
                //act
                var mockResult = controller.getCardDetailsForBooking(docId, date);
            }

            catch (HttpException ex)
            {
                // HttpException is expected
                Assert.AreEqual(404, (int)ex.GetHttpCode());
                //Assert.AreEqual("Not authorized.", ex.Message);
            }
            catch (Exception)
            {
                // Any other exception should cause the test to fail
                Assert.Fail();
            }

        }
    }
}
