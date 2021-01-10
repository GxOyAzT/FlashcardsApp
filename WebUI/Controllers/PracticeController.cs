using DatabaseModuleInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Processor;
using System;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [Authorize]
    public class PracticeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILoadFlashcardsForPracticeWhereGroupId _loadFlashcardsForPracticeWhereGroupId;
        private readonly ILoadFlashcardsForLearnWhereGroupId _loadFlashcardsForLearnWhereGroupId;
        private readonly ILoadFlashcardsForPracticeWhereUserId _loadFlashcardsForPracticeWhereUserId;
        private readonly ILoadFlashcardsForLearnWhereUserId _loadFlashcardsForLearnWhereUserId;
        private readonly IReCalculateAndUpdatePracticePropertiesList _reCalculateAndUpdatePracticePropertiesList;
        private readonly ICalculateIntervalsForHowManyFlashcards _calculateIntervalsForHowManyFlashcards;
        private readonly ICountHowManyFlashcardsForLearnWhereUserId _countHowManyFlashcardsForLearnWhereUserId;
        private readonly ICountHowManyFlashcardsForPracticeWhereUserId _countHowManyFlashcardsForPracticeWhereUserId;

        public PracticeController(
            UserManager<IdentityUser> userManager,
            ILoadFlashcardsForPracticeWhereGroupId loadFlashcardsForPracticeWhereGroupId,
            ILoadFlashcardsForLearnWhereGroupId loadFlashcardsForLearnWhereGroupId,
            ILoadFlashcardsForPracticeWhereUserId loadFlashcardsForPracticeWhereUserId,
            ILoadFlashcardsForLearnWhereUserId loadFlashcardsForLearnWhereUserId,
            IReCalculateAndUpdatePracticePropertiesList reCalculateAndUpdatePracticePropertiesList,
            ICalculateIntervalsForHowManyFlashcards calculateIntervalsForHowManyFlashcards,
            ICountHowManyFlashcardsForLearnWhereUserId countHowManyFlashcardsForLearnWhereUserId,
            ICountHowManyFlashcardsForPracticeWhereUserId countHowManyFlashcardsForPracticeWhereUserId)
        {
            _userManager = userManager;
            _loadFlashcardsForPracticeWhereGroupId = loadFlashcardsForPracticeWhereGroupId;
            _loadFlashcardsForLearnWhereGroupId = loadFlashcardsForLearnWhereGroupId;
            _loadFlashcardsForPracticeWhereUserId = loadFlashcardsForPracticeWhereUserId;
            _loadFlashcardsForLearnWhereUserId = loadFlashcardsForLearnWhereUserId;
            _reCalculateAndUpdatePracticePropertiesList = reCalculateAndUpdatePracticePropertiesList;
            _calculateIntervalsForHowManyFlashcards = calculateIntervalsForHowManyFlashcards;
            _countHowManyFlashcardsForLearnWhereUserId = countHowManyFlashcardsForLearnWhereUserId;
            _countHowManyFlashcardsForPracticeWhereUserId = countHowManyFlashcardsForPracticeWhereUserId;
        }

        [HttpGet]
        public async Task<IActionResult> Practice(int howMany, PracticeOrLearn practiceOrLearn, string groupId = null)
        {
            var model = new PracticeViewModel();

            var user = await _userManager.GetUserAsync(User);

            if (howMany == 0 || practiceOrLearn == PracticeOrLearn.Undefined)
            {
                RedirectToAction("BeforePractice");
            }

            if (practiceOrLearn == PracticeOrLearn.Learn && groupId == null)
                foreach (var item in _loadFlashcardsForLearnWhereUserId.Load(user.Id, howMany))
                    model.FlashcardPracticeModels.Add(item.ConvertToFlashcardPracticeModel());

            if (practiceOrLearn == PracticeOrLearn.Practice && groupId == null)
                foreach (var item in _loadFlashcardsForPracticeWhereUserId.Load(user.Id, howMany))
                    model.FlashcardPracticeModels.Add(item.ConvertToFlashcardPracticeModel());

            if (practiceOrLearn == PracticeOrLearn.Learn && groupId != null)
                foreach (var item in _loadFlashcardsForLearnWhereGroupId.Load(Guid.Parse("groupId"), howMany))
                    model.FlashcardPracticeModels.Add(item.ConvertToFlashcardPracticeModel());

            if (practiceOrLearn == PracticeOrLearn.Practice && groupId != null)
                foreach (var item in _loadFlashcardsForPracticeWhereGroupId.Load(Guid.Parse("groupId"), howMany))
                    model.FlashcardPracticeModels.Add(item.ConvertToFlashcardPracticeModel());

            return View(model);
        }

        [HttpPost]
        public IActionResult Practice(PracticeViewModel inputModel)
        {
            _reCalculateAndUpdatePracticePropertiesList.ReCauculate(inputModel.FlashcardPracticeModels);

            return RedirectToAction("Index", "Manage");
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
            return RedirectToAction("Practice", 
                new { howMany, practiceOrLearn = (PracticeOrLearn)learnOrPractice, groupId });
        }
    }
}
