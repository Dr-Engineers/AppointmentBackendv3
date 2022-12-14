using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
        [HttpGet]
        [Route("api/async/Tests")]
        public async Task<IHttpActionResult> GET()
        {
            var tests = await bl.getTestsAsync();
            if (tests.Count == 0)
                throw new HttpException(404, "Tests data not found");
            return Ok(tests);
        }
        [HttpPost]
        [Route("api/async/Tests/{testName}")]
        public async Task<IHttpActionResult> POST(string testName)
        {
            await bl.CreateTestAsync(testName);
            return Ok();
        }
    }
}
