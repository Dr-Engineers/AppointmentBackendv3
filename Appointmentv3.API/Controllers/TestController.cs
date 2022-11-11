using Appointmentv3.BL;
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
        [HttpPost]
        [Route("api/Tests/{testName}")]
        public IHttpActionResult POST(string testName)
        {
            bl.CreateTest(testName);
            return Ok();
        }
    }
}
