using Appointmentv3.BL;
using Appointmentv3.COMMON.DTO;
using Appointmentv3.COMMON.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
                throw new HttpException(404, $"No Appointment with Appointment ID: {AppointmentId}");
            return Ok(appointmentData);
        }

        [HttpPost]
        [Route("api/async/Appointment/{h}/{d}/{m}/{y}")]
        public async Task<IHttpActionResult> PostAppointment(CreatingAppointmentDTO creatingAppointment, int h, int d, int m, int y)
        {
            if (!ModelState.IsValid)
                throw new HttpException(400, "All fields not filled");
            Appointment appt = await repo.createAppointmentAsync(creatingAppointment, h, d, m ,y);
            if (appt == null)
                throw new HttpException(404, "Appointment not created");
            return Created($"api/GetAppointmentDetails/{appt.AppointmentID}", appt);

        }

        [HttpPut]
        [Route("api/async/Appointment/AppointmentID/{appointmentID}/{h}/{d}/{m}/{y}")]
        public async Task<IHttpActionResult> editAppointment(int appointmentID, Appointment editedAppointment, int h, int d, int m, int y)
        {
            if (!ModelState.IsValid)
                throw new HttpException(400, "All fields not filled");
            await repo.editAppointmentAsync(appointmentID, editedAppointment, h, d, m, y);
            return Ok();
        }
    }
}
