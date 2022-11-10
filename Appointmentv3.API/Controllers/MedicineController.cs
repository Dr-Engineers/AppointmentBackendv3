using Appointmentv3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Appointmentv3.BL;
using System.Web;

namespace Appointmentv3.API.Controllers
{
    public class MedicineController : ApiController
    {
        IBusinessLayer bl = null;
        public MedicineController(IBusinessLayer bl)
        {
            this.bl = bl;
        }


        [HttpGet]
        [Route("api/medicine")]
        public IHttpActionResult GET()
        {
            var medicines = bl.getMedicine();
            if (medicines.Count == 0)
                throw new HttpException(404, "Medicine data not available");
            return Ok(bl.getMedicine());
        }
    }
}
