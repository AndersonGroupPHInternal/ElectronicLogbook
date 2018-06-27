using ExternalAccountWebAuthentication.ApiController;
using ExternalAccountWebAuthentication.Authentication;

namespace ElectronicLogbookWeb.APIController
{
    [ApiAuthorizationFilter(false, new string[] { "ElectronicLogbookConsumer" })]
    public class BaseApiController : ExternalAccountBaseApiController
    {
    }
}
