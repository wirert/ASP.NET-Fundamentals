using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SMS.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
