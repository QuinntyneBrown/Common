using System.Web.Http;

namespace Common.Controllers
{
    public class BaseApiController: ApiController
    {
        [HttpGet]
        [Route("health")]
        public IHttpActionResult Health()
        {
            return Ok();
        }
    }
}
