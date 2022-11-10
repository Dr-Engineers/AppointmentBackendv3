using Appointmentv3.BL;
using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
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
        [Route("api/Appointment/AppointmentID/{AppointmentId}")]
        public IHttpActionResult GetAppointmentDetails(int AppointmentId)
        {
            var appointmentData = repo.getAppointment(AppointmentId);
            if (appointmentData == null)
                return NotFound();

            return Ok(appointmentData);
        }

        [HttpPost]
        [Route("api/Appointment")]
        public IHttpActionResult PostAppointment(CreatingAppointmentDTO creatingAppointment)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Appointment appt = repo.createAppointment(creatingAppointment);
            return Created($"api/GetAppointmentDetails/{appt.AppointmentID}", appt);

        }

        [HttpPut]
        [Route("api/Appointment/AppointmentID/{appointmentID}")]
        public IHttpActionResult editAppointment(int appointmentID, Appointment editedAppointment)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            repo.editAppointment(appointmentID, editedAppointment);
            return Ok();
        }
    }
}
