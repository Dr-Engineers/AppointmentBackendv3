using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Appointmentv3.BL;

namespace Appointmentv3.API.Controllers
{
    public class ClinicController : ApiController
    {
        IBusinessLayer bl = null;
        public ClinicController(IBusinessLayer bl)
        {
            this.bl = bl;
        }



        public IHttpActionResult GET()
        {
            return Ok(bl.getClinic());

        }
    }
}
