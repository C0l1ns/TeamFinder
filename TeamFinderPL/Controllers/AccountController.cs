using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TeamFinderDAL;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;
using TeamFinderDAL.Models.ViewModels;
using TeamFinderDAL.Repositories;
using TeamFinderBL.Interfaces;
using System.Collections.Generic;
using System;

namespace TeamFinderPL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private IAccountService _accountService { get; set; }

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
           IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
            _roleManager = roleManager;
        }


        // [AllowAnonymous]
        // public IActionResult Create()
        // {
        //     User user = new User();
        //
        //     return View(user);
        // }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User {UserName = model.Username, Email = model.Email, Password = model.Password};

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }


            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username/password.");
               
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        [HttpGet]
        [Authorize]
        public IActionResult CreateRole()
        {
            
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            await _accountService.CreateRole(roleName);
            return RedirectToAction(nameof(AccountController.GetRoles), "Account");
        }

        [HttpGet]
        [Authorize]

        public IActionResult AssignRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize]

        public async Task<IActionResult> AssignRole(AssignedRoles assignedRoles)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == assignedRoles.UserName);
            var roles = _roleManager.Roles
                .ToList()
                .Where(r => assignedRoles.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
                .Select(r => r.NormalizedName)
                .ToList();

            var result = await _userManager.AddToRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                throw new System.Exception(string.Join(';', result.Errors.Select(x => x.Description)));
            }
            return RedirectToAction(nameof(AccountController.GetRoles), "Account");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRoles()
        {
            var roles = (await _accountService.GetRoles()).Select(x => new Role { RoleName = x.Name });
            return View(roles);
        }
    }
}