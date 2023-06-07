using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebShopDemo.Core.Constants;

namespace WebShopDemo.Controllers
{
    /// <summary>
    /// Custom base controller for requiring authorization by default for derived controllers
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        /// <summary>
        /// Custom property for user first name extracted from claim
        /// </summary>
        public string UserFirstName
        {
            get
            {
                string firstName = string.Empty;

                if (User?.Identity?.IsAuthenticated ?? false &&
                    User.HasClaim(c => c.Type == DataConstants.ClaimType.FirstName))
                {
                    firstName = User!.Claims!.FirstOrDefault(c => c.Type == DataConstants.ClaimType.FirstName)!.Value;
                }

                return firstName;
            }
        }

        /// <summary>
        /// Put first name in ViewBag on every action if any authenticated user
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                ViewBag.UserFirstName = UserFirstName;
            }            

            base.OnActionExecuted(context);
        }
    }
}
