using Appointmentv3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        [HttpGet]
        [Route("api/async/petIssue")]
        public async Task<IHttpActionResult> GET()
        {
            var petIssues = await bl.getPetIssueAsync();
            if (petIssues.Count == 0)
                throw new HttpException(404, "PetIssue data not available");
            return Ok(petIssues);
        }
        [HttpPost]
        [Route("api/async/petIssue/{petIssueName}")]
        public async Task<IHttpActionResult> POST(string petIssueName)
        {
            await bl.CreatePetIssueAsync(petIssueName);
            return Ok();
        }
    }
}
