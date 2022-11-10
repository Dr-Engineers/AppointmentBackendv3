using Appointmentv3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Appointmentv3.API.Controllers
{
    public class SymptomAsyncController : ApiController
    {
        IBusinessLayerAsync bl = null;
        public SymptomAsyncController(IBusinessLayerAsync bl)
        {
            this.bl = bl;
        }

        [HttpGet]
        [Route("api/async/symptom")]
        public async Task<IHttpActionResult> GET()
        {
            var symptoms = await bl.getSymptomAsync();
            return Ok(symptoms);
        }
    }
}
