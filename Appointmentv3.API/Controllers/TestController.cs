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
    public class TestController : ApiController
    {
        IBusinessLayer bl = null;
        public TestController(IBusinessLayer bl)
        {
            this.bl = bl;
        }

        [HttpGet]
        [Route("api/Tests")]
        public IHttpActionResult GET()
        {
            var tests = bl.getTests();
            if (tests.Count == 0)
                throw new HttpException(404, "Tests data not available");
            return Ok(bl.getTests());
        }
    }
}
