using Appointmentv3.BL;
using Appointmentv3.COMMON.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace Appointmentv3.API.Controllers
{
    public class AppointmentCardController : ApiController
    {

        private IBusinessLayer bl = null;

        public AppointmentCardController(IBusinessLayer bl)
        {
            this.bl = bl;
        }

        [EnableQuery]
        [HttpGet]
        [Route("api/forDoctor/{doctorID}")]
        public IQueryable<CardDetailsDTO> getCardDetailsByDoctorID(int doctorID)
        {
            var doct = bl.getCardDetailsByDoctorID(doctorID).AsQueryable();
            if (doct.Count() == 0)
            {
                throw new HttpException(404, "No Appointments");
            }
            return doct;
        }

        [EnableQuery]
        [HttpGet]
        [Route("api/forPet/{petID}")]
        public IQueryable<CardDetailsDTO> getCardDetailsByPetID(int petID)
        {
            var pet = bl.getCardDetailsByPetID(petID).AsQueryable();
            if (pet.Count() == 0)
            {
                throw new HttpException(404, "No Appointments");
            }
            return pet;
        }

        [EnableQuery]
        [HttpGet]
        [Route("api/forBooking/doctorID/{doctorID}/date/{date}")]
        public IQueryable<CardDetailsDTO> getCardDetailsForBooking(int doctorID, DateTime date)
        {
            var booking = bl.getCardDetailsForBooking(doctorID, date).AsQueryable();
            if (booking.Count() == 0)
            {
                throw new HttpException(404, "No Appointments");
            }
            return booking;
        }
    }
}
