using Appointmentv3.BL;
using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
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
        [Route("api/Appointment/AppointmentID/{AppointmentId}")]
        public IHttpActionResult GetAppointmentDetails(int AppointmentId)
        {
            var appointmentData = repo.getAppointment(AppointmentId);
            if (appointmentData == null)
                throw new HttpException(404, $"No Appointment with Appointment ID: {AppointmentId}");

            return Ok(appointmentData);
        }

        [HttpPost]
        [Route("api/Appointment/{h}/{d}/{m}/{y}")]
        public IHttpActionResult PostAppointment(CreatingAppointmentDTO creatingAppointment, int h, int d, int m, int y)
        {
            if (!ModelState.IsValid)
                throw new HttpException(400, "All fields not filled");
            Appointment appt = repo.createAppointment(creatingAppointment, h, d, m, y);
            if (appt == null)
                throw new HttpException(404, "Appointment not created");
            return Created($"api/GetAppointmentDetails/{appt.AppointmentID}", appt);

        }

        [HttpPut]
        [Route("api/Appointment/AppointmentID/{appointmentID}/{h}/{d}/{m}/{y}")]
        public IHttpActionResult editAppointment(int appointmentID, Appointment editedAppointment, int h, int d, int m, int y)
        {
            if (!ModelState.IsValid)
                throw new HttpException(400, "All fields not filled");
            repo.editAppointment(appointmentID, editedAppointment, h, d, m, y);
            return Ok();
        }
    }
}
