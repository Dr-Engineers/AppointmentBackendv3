using Appointmentv3.BL;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appointmentv3.API.Controllers
{
    public class AppointmentCardAsyncController : ApiController
    {
        private IBusinessLayerAsync bl = null;

        public AppointmentCardAsyncController(IBusinessLayerAsync bl)
        {
            this.bl = bl;
        }

        [HttpGet]
        [Route("api/async/forDoctor/{doctorID}")]
        public async Task<IHttpActionResult> getCardDetailsByDoctorID(int doctorID)
        {
            var doct = await bl.getCardDetailsByDoctorIDAsync(doctorID);
            if (doct.Count == 0)
            {
                return NotFound();
            }
            return Ok(doct);
        }

        [HttpGet]
        [Route("api/async/forPet/{petID}")]
        public async  Task<IHttpActionResult> getCardDetailsByPetID(int petID)
        {
            var pet = await bl.getCardDetailsByPetIDAsync(petID);
            if (pet.Count == 0)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpGet]
        [Route("api/async/forBooking/doctorID/{doctorID}/date/{date}")]
        public async Task<IHttpActionResult> getCardDetailsForBooking(int doctorID, DateTime date)
        {
            var booking = await bl.getCardDetailsForBookingAsync(doctorID, date);
            if (booking.Count == 0)
            {
                return NotFound();
            }
            return Ok(booking);
        }
    }
}
