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
    public class SymptomController : ApiController
    {
        IBusinessLayer bl = null;
        public SymptomController(IBusinessLayer bl)
        {
            this.bl = bl;
        }


        [HttpGet]
        [Route("api/symptom")]
        public IHttpActionResult GET()
        {
            var symptoms = bl.getSymptom();
            if (symptoms.Count == 0)
                throw new HttpException(404, "symptoms data not available");
            return Ok(bl.getSymptom());
        }
        [HttpPost]
        [Route("api/symptom/{symptomName}")]
        public IHttpActionResult POST(string symptomName)
        {
            bl.CreateSymptom(symptomName);
            return Ok();
        }
    }
}
