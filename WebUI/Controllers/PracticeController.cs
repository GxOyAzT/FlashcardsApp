using DatabaseModuleInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Processor;
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
        private readonly ICalculateIntervalsForHowManyFlashcards _calculateIntervalsForHowManyFlashcards;
        private readonly ICountHowManyFlashcardsForLearnWhereUserId _countHowManyFlashcardsForLearnWhereUserId;
        private readonly ICountHowManyFlashcardsForPracticeWhereUserId _countHowManyFlashcardsForPracticeWhereUserId;

        public PracticeController(
            UserManager<IdentityUser> userManager, 
            ILoadFiveFlashcardsForLearnWherUserId loadFiveFlashcardsForLearnWherUserId,
            ILoadFiveFlashcardsForPracticeWhereUserId loadFiveFlashcardsForPracticeWhereUserId,
            IReCalculateAndUpdatePracticePropertiesList reCalculateAndUpdatePracticePropertiesList,
            ICalculateIntervalsForHowManyFlashcards calculateIntervalsForHowManyFlashcards,
            ICountHowManyFlashcardsForLearnWhereUserId countHowManyFlashcardsForLearnWhereUserId,
            ICountHowManyFlashcardsForPracticeWhereUserId countHowManyFlashcardsForPracticeWhereUserId)
        {
            _userManager = userManager;
            _loadFiveFlashcardsForLearnWherUserId = loadFiveFlashcardsForLearnWherUserId;
            _loadFiveFlashcardsForPracticeWhereUserId = loadFiveFlashcardsForPracticeWhereUserId;
            _reCalculateAndUpdatePracticePropertiesList = reCalculateAndUpdatePracticePropertiesList;
            _calculateIntervalsForHowManyFlashcards = calculateIntervalsForHowManyFlashcards;
            _countHowManyFlashcardsForLearnWhereUserId = countHowManyFlashcardsForLearnWhereUserId;
            _countHowManyFlashcardsForPracticeWhereUserId = countHowManyFlashcardsForPracticeWhereUserId;
        }

        [HttpGet]
        public async Task<IActionResult> Practice(int howMany, int learnOrPractice, string groupId = null)
        {
            if (howMany == 0 || learnOrPractice == 0)
            {
                RedirectToAction("BeforePractice");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Practice(PracticeViewModel inputModel)
        {
            _reCalculateAndUpdatePracticePropertiesList.ReCauculate(inputModel.FlashcardPracticeModels);

            return RedirectToAction("Practice");
        }

        [HttpGet]
        public IActionResult BeforePractice(BeforePracticeViewModel model)
        {
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> BeforePracticeWhereUserId()
        {
            var user = await _userManager.GetUserAsync(User);

            return RedirectToAction("BeforePractice", new BeforePracticeViewModel()
            {
                HowManyNewFlashcardsLearnList = _calculateIntervalsForHowManyFlashcards
                .Claculate(_countHowManyFlashcardsForLearnWhereUserId
                .Count(user.Id)),

                HowManyNewFlashcardsPracticeList = _calculateIntervalsForHowManyFlashcards
                .Claculate(_countHowManyFlashcardsForPracticeWhereUserId
                .Count(user.Id))
            });
        }

        [HttpPost]
        public IActionResult BeforePractice(int howMany, int learnOrPractice, string groupId = null)
        {
            return RedirectToAction("Practice", new { howMany, learnOrPractice, groupId });
        }
    }
}
