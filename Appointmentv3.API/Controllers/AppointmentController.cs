using Appointmentv3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Appointmentv3.API.Controllers
{
    public class AppointmentController : ApiController
    {
        IBusinessLayer repo = null;

        public AppointmentController(IBusinessLayer repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IHttpActionResult GetAppointmentDetails(int AppointmentId)
        {
            var appointmentData = repo.getAppointment(AppointmentId);
            if (appointmentData == null)
                return NotFound();

            return Ok(appointmentData);
        }







    }
}
