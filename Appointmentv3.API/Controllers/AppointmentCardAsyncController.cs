using Appointmentv3.BL;
using Appointmentv3.COMMON.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace Appointmentv3.API.Controllers
{
    public class AppointmentCardAsyncController : ApiController
    {
        private IBusinessLayerAsync bl = null;

        public AppointmentCardAsyncController(IBusinessLayerAsync bl)
        {
            this.bl = bl;
        }

        [EnableQuery]
        [HttpGet]
        [Route("api/async/forDoctor/{doctorID}")]
        
        public async Task<IQueryable<CardDetailsDTO>> getCardDetailsByDoctorID(int doctorID)
        {
            var doct = await bl.getCardDetailsByDoctorIDAsync(doctorID);
            if (doct.Count == 0)
            {
                throw new HttpException(404, "No Appointments");
            }
            return doct.AsQueryable();
        }


        [EnableQuery]
        [HttpGet]
        [Route("api/async/forPet/{petID}")]
        public async  Task<IQueryable<CardDetailsDTO>> getCardDetailsByPetID(int petID)
        {
            var pet = await bl.getCardDetailsByPetIDAsync(petID);
            if (pet.Count == 0)
            {
                throw new HttpException(404, "No Appointments");
            }
            return pet.AsQueryable();
        }

        [EnableQuery]
        [HttpGet]
        [Route("api/async/forBooking/doctorID/{doctorID}/date/{date}")]
        public async Task<IQueryable<CardDetailsDTO>> getCardDetailsForBooking(int doctorID, DateTime date)
        {
            var booking = await bl.getCardDetailsForBookingAsync(doctorID, date);
            if (booking.Count == 0)
            {
                throw new HttpException(404, "No Appointments");
            }
            return booking.AsQueryable();
        }
    }
}
