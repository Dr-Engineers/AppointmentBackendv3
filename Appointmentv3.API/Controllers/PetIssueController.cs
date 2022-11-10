using Appointmentv3.BL;
using System.Web.Http;

namespace Appointmentv3.API.Controllers
{
    public class PetIssueController : ApiController
    {
        IBusinessLayer bl = null;
        public PetIssueController(IBusinessLayer bl)
        {
            this.bl = bl;
        }


        [HttpGet]
        [Route("api/petIssue")]
        public IHttpActionResult GET()
        {
            return Ok(bl.getPetIssue());
        }
    }
}
