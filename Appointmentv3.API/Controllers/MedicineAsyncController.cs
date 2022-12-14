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
            if (medicines.Count == 0)
                throw new HttpException(404, "Medicine data not available");
            return Ok(medicines);
        }
        [HttpPost]
        [Route("api/async/medicine/{medicineName}")]
        public async Task<IHttpActionResult> POST(string medicineName)
        {
            await bl.CreateMedicineAsync(medicineName);
            return Ok();
        }
    }
}
