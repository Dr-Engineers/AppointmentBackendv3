using Appointmentv3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Appointmentv3.BL;

namespace Appointmentv3.API.Controllers
{
    public class SymptomController : ApiController
    {
        IBusinessLayer bl = null;
        public SymptomController(IBusinessLayer bl)
        {
            this.bl = bl;
        }



        public IHttpActionResult GET()
        {
            return Ok(bl.getSymptom());
        }
    }
}
