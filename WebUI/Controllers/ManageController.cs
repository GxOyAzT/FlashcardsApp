using DatabaseModuleInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoadAllUserGroups _loadAllUserGroups;
        private readonly IDeleteGroup _deleteGroup;
        private readonly ICreateNewGroup _createNewGroup;
        private readonly ICheckIfUserOwnGroup _checkIfUserOwnGroup;
        private readonly ILoadFlashcardsWhereGroupId _loadFlashcardsWhereGroupId;

        public ManageController(
            UserManager<IdentityUser> userManager, 
            ILoadAllUserGroups loadAllUserGroups, 
            IDeleteGroup deleteGroup,
            ICreateNewGroup createNewGroup, 
            ICheckIfUserOwnGroup checkIfUserOwnGroup,
            ILoadFlashcardsWhereGroupId loadFlashcardsWhereGroupId)
        {
            _loadAllUserGroups = loadAllUserGroups;
            _userManager = userManager;
            _deleteGroup = deleteGroup;
            _createNewGroup = createNewGroup;
            _checkIfUserOwnGroup = checkIfUserOwnGroup;
            _loadFlashcardsWhereGroupId = loadFlashcardsWhereGroupId;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GroupsList(List<string> errorMessages)
        {
            var user = await _userManager.GetUserAsync(User);
            return View(new GroupsListViewModel(_loadAllUserGroups.Load(user.Id), errorMessages));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGroup(string groupId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (!_checkIfUserOwnGroup.Check(user.Id, Guid.Parse(groupId)))
                RedirectToAction("GroupsList", new { errorMessages = "You have no permission to do that" });

            _deleteGroup.Delete(Guid.Parse(groupId));
            return RedirectToAction("GroupsList");
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(string groupName, string description)
        {
            var user = await _userManager.GetUserAsync(User);

            if (!_createNewGroup.Create(groupName, description, user.Id))
                return RedirectToAction("GroupsList", new { errorMessages = _createNewGroup.GetUserMessages() });

            return RedirectToAction("GroupsList");
        }

        public IActionResult FlashcardsList(string groupId, List<string> errorMessages = null)
        {
            return View(new FlashcardsListViewModel(_loadFlashcardsWhereGroupId.Load(Guid.Parse(groupId)).Where(e => e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign).ToList(), errorMessages));
        }

        public IActionResult CreateFlashcard(string native, string foreign)
        {

        }
    }
}
