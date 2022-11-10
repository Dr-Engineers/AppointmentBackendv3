using Appointmentv3.API.Controllers;
using Appointmentv3.BL;
using Appointmentv3.COMMON.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            mockBL.Setup(x => x.getAppointmentAsync(2)).ReturnsAsync(appointment);
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
    }
}
