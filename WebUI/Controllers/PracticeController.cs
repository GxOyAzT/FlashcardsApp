using DatabaseModuleInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Processor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Authorize]
    public class PracticeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoadFiveFlashcardsForLearnWherUserId _loadFiveFlashcardsForLearnWherUserId;
        private readonly ILoadFiveFlashcardsForPracticeWhereUserId _loadFiveFlashcardsForPracticeWhereUserId;
        private readonly IReCalculateAndUpdatePracticePropertiesList _reCalculateAndUpdatePracticePropertiesList;

        public PracticeController(
            UserManager<IdentityUser> userManager, 
            ILoadFiveFlashcardsForLearnWherUserId loadFiveFlashcardsForLearnWherUserId,
            ILoadFiveFlashcardsForPracticeWhereUserId loadFiveFlashcardsForPracticeWhereUserId,
            IReCalculateAndUpdatePracticePropertiesList reCalculateAndUpdatePracticePropertiesList)
        {
            _userManager = userManager;
            _loadFiveFlashcardsForLearnWherUserId = loadFiveFlashcardsForLearnWherUserId;
            _loadFiveFlashcardsForPracticeWhereUserId = loadFiveFlashcardsForPracticeWhereUserId;
            _reCalculateAndUpdatePracticePropertiesList = reCalculateAndUpdatePracticePropertiesList;
        }

        [HttpGet]
        public async Task<IActionResult> Practice()
        {
            List<FlashcardPracticeModel> practiceFlashcards = new List<FlashcardPracticeModel>();

            var user = await _userManager.GetUserAsync(User);

            foreach (var item in _loadFiveFlashcardsForPracticeWhereUserId.Load(user.Id))
            {
                practiceFlashcards.Add(new FlashcardPracticeModel()
                {
                    Id = item.Id,
                    ForeignLanguage = item.ForeignLanguage,
                    NativeLanguage = item.NativeLanguage,
                    PracticeDirection = item.PracticeDirection,
                    FlashcardKnowledgeInt = -1,
                    CorreactAnsInRow = item.CorreactAnsInRow
                });
            }

            return View(new PracticeViewModel(practiceFlashcards.Count, practiceFlashcards));
        }

        [HttpPost]
        public IActionResult Practice(PracticeViewModel inputModel)
        {
            _reCalculateAndUpdatePracticePropertiesList.ReCauculate(inputModel.FlashcardPracticeModels);

            return RedirectToAction("Practice");
        }
    }
}
