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
    public class ClinicController : ApiController
    {
        IBusinessLayer bl = null;
        public ClinicController(IBusinessLayer bl)
        {
            this.bl = bl;
        }


        [HttpGet]
        [Route("api/clinic")]
        public IHttpActionResult GET()
        {
            var clinics=bl.getClinic();
            if (clinics.Count == 0)
                throw new HttpException(404, "Clinic data not available");

            return Ok(bl.getClinic());
        }
        [HttpPost]
        [Route("api/clinic/{clinicName}")]
        public IHttpActionResult POST(string clinicName)
        {
            bl.CreateClinc(clinicName);
            return Ok();
        }
    }
}
