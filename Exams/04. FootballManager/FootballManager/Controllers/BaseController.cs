using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
