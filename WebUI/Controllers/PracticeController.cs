using DatabaseModuleInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            List<PracticeFlashcard> practiceFlashcards = new List<PracticeFlashcard>();

            var user = await _userManager.GetUserAsync(User);

            foreach (var item in _loadFiveFlashcardsForLearnWherUserId.Load(user.Id))
            {
                practiceFlashcards.Add(new PracticeFlashcard()
                {
                    Id = item.Id.ToString(),
                    Foreign = item.ForeignLanguage,
                    Native = item.NativeLanguage,
                    PracticeDirection = (int)item.PracticeDirection
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
