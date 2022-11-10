using Appointmentv3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Appointmentv3.API.Controllers
{
    public class AppointmentCardController : ApiController
    {

        private IBusinessLayer bl = null;

        public AppointmentCardController(IBusinessLayer bl)
        {
            this.bl = bl;
        }

        [HttpGet]
        [Route("api/forDoctor/{doctorID}")]
        public IHttpActionResult getCardDetailsByDoctorID(int doctorID)
        {
            var doct = bl.getCardDetailsByDoctorID(doctorID);
            if (doct.Count == 0)
            {
                return NotFound();
            }
            return Ok(doct);
        }

        [HttpGet]
        [Route("api/forPet/{petID}")]
        public IHttpActionResult getCardDetailsByPetID(int petID)
        {
            var pet = bl.getCardDetailsByPetID(petID);
            if (pet.Count == 0)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        [HttpGet]
        [Route("api/forBooking/doctorID/{doctorID}/date/{date}")]
        public IHttpActionResult getCardDetailsForBooking(int doctorID, DateTime date)
        {
            var booking = bl.getCardDetailsForBooking(doctorID, date);
            if (booking.Count == 0)
            {
                return NotFound();
            }
            return Ok(booking);
        }
    }
}
