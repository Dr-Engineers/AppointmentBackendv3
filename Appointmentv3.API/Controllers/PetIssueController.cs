using Appointmentv3.BL;
using System.Web.Http;
using Appointmentv3.BL;
using System.Web;

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
            var petIssue = bl.getPetIssue();
            if (petIssue.Count == 0)
                throw new HttpException(404, "PetIssue data not available");
            return Ok(bl.getPetIssue());
        }
        [HttpPost]
        [Route("api/petIssue/{petIssue}")]
        public IHttpActionResult POST(string petIssue)
        {
            bl.CreatePetIssue(petIssue);
            return Ok();
        }
    }
}
