using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Controllers
{
    /// <summary>
    /// Base Controller for all controllers (make them with 'Authorize' attribute by default)
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
