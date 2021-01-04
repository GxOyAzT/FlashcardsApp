using DatabaseModuleInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ManageController : Controller
    {
        private readonly ILoadAllUserGroups _loadAllUserGroups;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IDeleteGroup _deleteGroup;

        public ManageController(ILoadAllUserGroups loadAllUserGroups, UserManager<IdentityUser> userManager, IDeleteGroup deleteGroup)
        {
            _loadAllUserGroups = loadAllUserGroups;
            _userManager = userManager;
            _deleteGroup = deleteGroup;
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
            _deleteGroup.Delete(Guid.Parse(flashcardId));
            return RedirectToAction("GroupsList");
        }
    }
}
