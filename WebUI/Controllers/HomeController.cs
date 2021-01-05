using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAppAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginRegister(List<string> errorMessages = null)
        {
            return View(errorMessages);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (email == null || email == string.Empty || password == null || password == string.Empty)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "Incorrect data input." } });
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "This e-mail does not exists." } });
            }

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (!result.Succeeded)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "Incorrect password." } });
            }

            return RedirectToAction("Index", "Manage");
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string repeatPassword, string userName)
        {
            if (email == null || email == string.Empty || password == null || password == string.Empty || repeatPassword == null || repeatPassword == string.Empty)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "Incorrect data input." } });
            }

            if(password != repeatPassword)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "Passwords do not match." } });
            }

            if(await _userManager.FindByEmailAsync(email) != null)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "This e-mail already exists." } });
            }

            if (await _userManager.FindByNameAsync(userName) != null)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = new List<string>() { "This user name already exists." } });
            }

            var passwordValidator = new PasswordValidator<IdentityUser>();
            var passwordValidateResult = await passwordValidator.ValidateAsync(_userManager, null, password);

            if (!passwordValidateResult.Succeeded)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = "Password Passwords must be at least 6 characters, at least one lowercase('a' - 'z'), at least one uppercase('A' - 'Z'), at least one digit('0' - '9'), at least one non alphanumeric character." } );
            }

            var user = new IdentityUser
            {
                Email = email,
                UserName = userName
            };

            var userCreateResult = await _userManager.CreateAsync(user, password);

            if (!userCreateResult.Succeeded)
            {
                return RedirectToAction("LoginRegister",
                    new { errorMessages = "An error occured when creating account. Try again later or contact support." });
            }

            return RedirectToAction("LoginRegister",
                    new { errorMessages = "Account created successfully." });
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LoginRegister",
                    new { errorMessages = "Successfully logged out." });
        }
    }
}
