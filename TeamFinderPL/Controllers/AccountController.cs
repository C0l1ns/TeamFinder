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


namespace TeamFinderPL.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [AllowAnonymous]
        public IActionResult Create()
        {
            User user = new User();

            return View(user);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // [AllowAnonymous]
        // [HttpPost]
        // public async Task<IActionResult> Register(AccountRegisterViewModel model)
        // {
        //
        //     if (ModelState.IsValid)
        //     {
        //         User myUser = new User
        //         {
        //             Username = model.Username, Email = model.Email, Password = model.Password,
        //             DisplayUsername = model.DisplayUsername
        //         };
        //         _userRepository.Create(myUser);
        //         _userRepository.Save();
        //         IdentityUser genericUser = new IdentityUser { UserName = model.Username, Email = model.Email};
        //
        //         var result = await _userManager.CreateAsync(genericUser, model.Password);
        //
        //         if (result.Succeeded)
        //         {
        //             await _signInManager.SignInAsync(genericUser, isPersistent: false);
        //             return RedirectToAction("Index", "Home");
        //         }
        //
        //         foreach (var error in result.Errors)
        //         {
        //             ModelState.AddModelError("", error.Description);
        //         }
        //         
        //     }
        //
        //
        //     return View(model);
        // }

        [AllowAnonymous]
        public IActionResult Login(string username, string password)
        {
            return View();
        }


        // public IActionResult Login(User model, string returnUrl)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(model);
        //     }
        //
        //     _signInManager.SignOutAsync();
        //     var result = signin.PasswordSignIn(
        //         model.Username, model.Password, isPersistent: model.RememberME,
        //         lockoutOnFailure: false);
        //
        //     // This doesn't count login failures towards account lockout
        //     // To enable password failures to trigger account lockout, change to shouldLockout: true
        //
        //     if (result.Succeeded)
        //     {
        //         return RedirectToAction("Index", "Home");
        //     }
        //
        //     ModelState.AddModelError("", "Invalid username/password.");
        //     return View(model);
        // }

        [Authorize]
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}