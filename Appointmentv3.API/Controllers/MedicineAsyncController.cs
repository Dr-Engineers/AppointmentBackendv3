using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Appointmentv3.BL;

namespace Appointmentv3.API.Controllers
{
    public class MedicineAsyncController : ApiController
    {
        IBusinessLayerAsync bl = null;
        public MedicineAsyncController(IBusinessLayerAsync bl)
        {
            this.bl = bl;
        }


        [HttpGet]
        [Route("api/async/medicine")]
        public async Task<IHttpActionResult> GET()
        {
            var medicines =await bl.getMedicineAsync();
            return Ok(medicines);
        }
    }
}
