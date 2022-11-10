using Appointmentv3.BL;
using System.Web.Http;

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
        public IHttpActionResult GetTests()
        {
            return Ok(bl.getTests());
        }
    }
}
