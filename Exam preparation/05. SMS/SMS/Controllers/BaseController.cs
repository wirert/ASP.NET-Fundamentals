using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SMS.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public string GetUserName()
            => User.FindFirstValue(ClaimTypes.Name);

        public string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
