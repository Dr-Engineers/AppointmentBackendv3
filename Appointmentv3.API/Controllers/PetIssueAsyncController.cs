using Appointmentv3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Appointmentv3.API.Controllers
{
    public class PetIssueAsyncController : ApiController
    {
        IBusinessLayerAsync bl = null;
        public PetIssueAsyncController(IBusinessLayerAsync bl)
        {
            this.bl = bl;
        }

        public IHttpActionResult GET()
        {
            return Ok(bl.getPetIssueAsync());
        }
    }
}
