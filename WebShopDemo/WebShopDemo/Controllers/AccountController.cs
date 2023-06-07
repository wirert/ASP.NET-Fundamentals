using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebShopDemo.Core.Constants;
using WebShopDemo.Core.Data.Models.Account;
using WebShopDemo.Models;

namespace WebShopDemo.Controllers
{
    /// <summary>
    /// Account controller for log, logout and register users
    /// </summary>
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        /// <summary>
        /// Register action for registration of users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        /// <summary>
        /// Register action for registration of users
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                UserName = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            await userManager
                .AddClaimAsync(user, new System.Security.Claims.Claim(
                    DataConstants.ClaimType.FirstName, user.FirstName ?? user.Email));

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        /// <summary>
        /// User Logging in
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        /// <summary>
        /// User Logging in
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.IsPersistent, false);

                if (result.Succeeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid login");
            }

            return View(model);
        }

        /// <summary>
        /// User log out action
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Create roles
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = DataConstants.Roles.Supervisor)]
        public async Task<IActionResult> CreateRoles()
        {
            await roleManager.CreateAsync(new IdentityRole(DataConstants.Roles.Admin));
            await roleManager.CreateAsync(new IdentityRole(DataConstants.Roles.Manager));
            await roleManager.CreateAsync(new IdentityRole(DataConstants.Roles.Supervisor));

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Add user to role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Policy = DataConstants.Policies.CanAddRolesToUsers)]
        public async Task<IActionResult> AddRole()
        {
            ViewBag.Title = "Select user and role";
            ViewBag.Roles = await roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.UsersEmails = await userManager.Users.Select(u => u.Email).ToListAsync();

            var model = new AddRoleViewModel();
           
            return View(model);
        }

        /// <summary>
        /// Add user to role
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Policy = DataConstants.Policies.CanAddRolesToUsers)]
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            //var role = await roleManager.FindByNameAsync(model.RoleName);

            if (user == null)
            {
                return View(model);
            }

            await userManager.AddToRoleAsync(user!, model.RoleName);

            return RedirectToAction("Index", "Home");
        }
    }
}
