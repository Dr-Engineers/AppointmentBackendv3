using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Appointmentv3.BL;

namespace Appointmentv3.API.Controllers
{
    public class TestAsyncController : ApiController
    {
        IBusinessLayerAsync bl = null;
        public TestAsyncController(IBusinessLayerAsync bl)
        {
            this.bl = bl;
        }

        public async IHttpActionResult GET()
        {
            var test = await bl.getTestsAsync();
            return  Ok(bl.getTestsAsync());
        }
    }
}
