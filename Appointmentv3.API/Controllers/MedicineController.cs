using Appointmentv3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Appointmentv3.API.Controllers
{
    public class MedicineController : ApiController
    {
        IBusinessLayer bl = null;
        public MedicineController(IBusinessLayer bl)
        {
            this.bl = bl;
        }



        public IHttpActionResult GET()
        {
            return Ok(bl.getMedicine());
        }
    }
}
