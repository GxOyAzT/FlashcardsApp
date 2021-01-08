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
        public IActionResult BeforePractice()
        {
            return View(new BeforePracticeViewModel()
            {
                HowManyNewFlashcardsLearnList = new List<int>() { 2,5,10,15},
                HowManyNewFlashcardsPracticeList = new List<int>() { 2, 5 }
            });
        }

        [HttpPost]
        public IActionResult BeforePractice(int howMany, int learnOrPractice, string groupId = null)
        {
            return RedirectToAction("Practice", new { howMany, learnOrPractice, groupId });
        }
    }
}
