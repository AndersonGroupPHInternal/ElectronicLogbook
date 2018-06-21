using System.Web.Http;

namespace ElectronicLogbookWeb.APIController
{
    public class TestApiController : BaseApiController
    {
        [HttpPost]
        public IHttpActionResult LoggedOut()
        {
            return Ok();
        }
    }
}
