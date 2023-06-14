using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusStation.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
