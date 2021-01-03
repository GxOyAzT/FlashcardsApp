using DatabaseModuleInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ManageController : Controller
    {
        private readonly ILoadAllUserGroups _loadAllUserGroups;
        private readonly UserManager<IdentityUser> _userManager;

        public ManageController(ILoadAllUserGroups loadAllUserGroups, UserManager<IdentityUser> userManager)
        {
            _loadAllUserGroups = loadAllUserGroups;
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GroupsList()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(_loadAllUserGroups.Load(user.Id));
        }

        public IActionResult DeleteGroup(string flashcardId)
        {
            return View();
        }
    }
}
