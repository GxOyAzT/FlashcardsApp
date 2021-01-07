using DatabaseModuleInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Authorize]
    public class PracticeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoadFiveFlashcardsForLearnWherUserId _loadFiveFlashcardsForLearnWherUserId;

        public PracticeController(
            UserManager<IdentityUser> userManager, 
            ILoadFiveFlashcardsForLearnWherUserId loadFiveFlashcardsForLearnWherUserId)
        {
            _userManager = userManager;
            _loadFiveFlashcardsForLearnWherUserId = loadFiveFlashcardsForLearnWherUserId;
        }

        [HttpGet]
        public async Task<IActionResult> Practice()
        {
            List<FlashcardPracticeModel> practiceFlashcards = new List<FlashcardPracticeModel>();

            var user = await _userManager.GetUserAsync(User);

            foreach (var item in _loadFiveFlashcardsForLearnWherUserId.Load(user.Id))
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


            return View();
        }
    }
}
