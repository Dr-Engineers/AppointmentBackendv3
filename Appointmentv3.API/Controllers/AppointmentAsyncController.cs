using Appointmentv3.BL;
using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appointmentv3.API.Controllers
{
    public class AppointmentAsyncController : ApiController
    {
        IBusinessLayerAsync repo = null;

        public AppointmentAsyncController(IBusinessLayerAsync repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("api/async/Appointment/AppointmentID/{AppointmentId}")]
        public async Task<IHttpActionResult> GetAppointmentDetails(int AppointmentId)
        {
            var appointmentData =  await repo.getAppointmentAsync(AppointmentId);
            if (appointmentData == null)
                return NotFound();

            return Ok(appointmentData);
        }

        [HttpPost]
        [Route("api/async/Appointment")]
        public async Task<IHttpActionResult> PostAppointment(CreatingAppointmentDTO creatingAppointment)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            Appointment appt = await repo.createAppointmentAsync(creatingAppointment);
            return Created($"api/GetAppointmentDetails/{appt.AppointmentID}", appt);

        }

        [HttpPut]
        [Route("api/async/Appointment/AppointmentID/{appointmentID}")]
        public async Task<IHttpActionResult> editAppointment(int appointmentID, Appointment editedAppointment)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await repo.editAppointmentAsync(appointmentID, editedAppointment);
            return Ok();
        }
    }
}
