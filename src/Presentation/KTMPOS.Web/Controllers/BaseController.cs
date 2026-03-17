using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace KTMPOS.Web.Controllers
{
    [Route("[Controller]")]
    [Authorize]
    public class BaseController : Controller
    {
        protected int GetCurrentUserId()
        {
            string userIdClaim = User
                                 .Claims
                                 .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                                 .Value;
            return Convert.ToInt32(userIdClaim);
        }
    }
}