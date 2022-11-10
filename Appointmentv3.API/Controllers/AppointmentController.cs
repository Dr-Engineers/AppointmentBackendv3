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
        [Route("api/Appointment")]
        public IHttpActionResult PostAppointment(CreatingAppointmentDTO creatingAppointment)
        {
            if (!ModelState.IsValid)
                throw new HttpException(400, "All fields not filled");
            Appointment appt = repo.createAppointment(creatingAppointment);
            return Created($"api/GetAppointmentDetails/{appt.AppointmentID}", appt);

        }

        [HttpPut]
        [Route("api/Appointment/AppointmentID/{appointmentID}")]
        public IHttpActionResult editAppointment(int appointmentID, Appointment editedAppointment)
        {
            if (!ModelState.IsValid)
                throw new HttpException(400, "All fields not filled");
            repo.editAppointment(appointmentID, editedAppointment);
            return Ok();
        }
    }
}
