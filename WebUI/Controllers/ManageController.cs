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
        private readonly ICreateFlashcard _createFlashcard;
        private readonly IUpdateFlashcard _updateFlashcard;
        private readonly IDeleteFlashcard _deleteFlashcard;
        private readonly ICountHowManyFlashcardsUserHas _countHowManyFlashcardsUserHas;
        private readonly ICountNewFlashcardsWhereUserId _countNewFlashcardsWhereUserId;

        public ManageController(
            UserManager<IdentityUser> userManager, 
            ILoadAllUserGroups loadAllUserGroups, 
            IDeleteGroup deleteGroup,
            ICreateNewGroup createNewGroup, 
            ICheckIfUserOwnGroup checkIfUserOwnGroup,
            ILoadFlashcardsWhereGroupId loadFlashcardsWhereGroupId,
            ICreateFlashcard createFlashcard,
            IUpdateFlashcard updateFlashcard,
            IDeleteFlashcard deleteFlashcard,
            ICountHowManyFlashcardsUserHas countHowManyFlashcardsUserHas,
            ICountNewFlashcardsWhereUserId countNewFlashcardsWhereUserId)
        {
            _loadAllUserGroups = loadAllUserGroups;
            _userManager = userManager;
            _deleteGroup = deleteGroup;
            _createNewGroup = createNewGroup;
            _checkIfUserOwnGroup = checkIfUserOwnGroup;
            _loadFlashcardsWhereGroupId = loadFlashcardsWhereGroupId;
            _createFlashcard = createFlashcard;
            _updateFlashcard = updateFlashcard;
            _deleteFlashcard = deleteFlashcard;
            _countHowManyFlashcardsUserHas = countHowManyFlashcardsUserHas;
            _countNewFlashcardsWhereUserId = countNewFlashcardsWhereUserId;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            return View(new ManageIndexViewModel()
            {
                FlashcardsCount = _countHowManyFlashcardsUserHas.Count(user.Id),
                FlashcardsForLearnCount = _countNewFlashcardsWhereUserId.Count(user.Id)
            });
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
            return View(new FlashcardsListViewModel(
                _loadFlashcardsWhereGroupId.Load(Guid.Parse(groupId)).Where(e => e.PracticeDirection == Models.PracticeDirection.FromNativeToForeign).ToList(), 
                errorMessages,
                groupId));
        }

        public IActionResult CreateFlashcard(string native, string foreign, string groupId)
        {
            if (!_createFlashcard.Create(native, foreign, Guid.Parse(groupId)))
                return RedirectToAction("FlashcardsList", new { groupId = groupId, errorMessages = _createFlashcard.GetUserMessages() });

            return RedirectToAction("FlashcardsList", new { groupId = groupId, errorMessages = new List<string>() });
        }

        public async Task<IActionResult> ModifyFlashcard(string modifyFlashcardId, string native, string foreign, string groupId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (!_checkIfUserOwnGroup.Check(user.Id, Guid.Parse(groupId)))
                RedirectToAction("FlashcardsList", new { groupId = groupId, errorMessages = "You have no permission to do that" });

            if (!_updateFlashcard.Update(native, foreign, Guid.Parse(modifyFlashcardId), Guid.Parse(groupId)))
                return RedirectToAction("FlashcardsList", new { groupId = groupId, errorMessages = _updateFlashcard.GetUserMessages() });

            return RedirectToAction("FlashcardsList", new { groupId = groupId, errorMessages = new List<string>() });
        }

        public async Task<IActionResult> DeleteFlashcard(string flashcardId, string groupId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (!_checkIfUserOwnGroup.Check(user.Id, Guid.Parse(groupId)))
                return RedirectToAction("FlashcardsList", new { groupId = groupId, errorMessages = "You have no permission to do that" });

            _deleteFlashcard.Delete(Guid.Parse(flashcardId));

            return RedirectToAction("FlashcardsList", new { groupId = groupId, errorMessages = new List<string>() });
        }
    }
}
