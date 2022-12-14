using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Appointmentv3.BL;

namespace Appointmentv3.API.Controllers
{
    public class ClinicAsyncController : ApiController
    {
        IBusinessLayerAsync bl = null;
        public ClinicAsyncController(IBusinessLayerAsync bl)
        {
            this.bl = bl;
        }


        [HttpGet]
        [Route("api/async/clinic")]
        public async Task<IHttpActionResult> GET()
        {
            var clinics=await bl.getClinicAsync();
            if (clinics.Count == 0)
                throw new HttpException(404, "Clinic data not available");
            return Ok(clinics);
        }
        [HttpPost]
        [Route("api/async/clinic/{clinicName}")]
        public async Task<IHttpActionResult> POST(string clinicName)
        {
            await bl.CreateClinicAsync(clinicName);
            return Ok();
        }
    }
}
