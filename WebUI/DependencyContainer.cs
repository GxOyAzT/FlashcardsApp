using DatabaseModule;
using DatabaseModuleInterface;
using Microsoft.Extensions.DependencyInjection;
using Processor;

namespace WebUI
{
    public class DependencyContainer
    {
        public static void MapDependencies(IServiceCollection services)
        {
            services.AddScoped<ILoadAllUserGroups, LoadAllUserGroups>();
            services.AddScoped<IDeleteGroup, DeleteGroup>();
            services.AddScoped<IInsertNewGroup, InsertNewGroup>();
            services.AddScoped<IValidateGroupModel, ValidateGroupModel>();
            services.AddScoped<IValidateGroupName, ValidateGroupName>();
            services.AddScoped<IValidateGroupDescription, ValidateGroupDescription>();
            services.AddScoped<ICreateNewGroup, CreateNewGroup>();
            services.AddScoped<ICheckIfGroupIdIsUnique, CheckIfGroupIdIsUnique>();
            services.AddScoped<ICheckIfUserOwnGroup, CheckIfUserOwnGroup>();
            services.AddScoped<ILoadFlashcardsWhereGroupId, LoadFlashcardsWhereGroupId>();
            services.AddScoped<ICreateFlashcard, CreateFlashcard>();
            services.AddScoped<ICheckIfFlashcardIdIsUnique, CheckIfFlashcardIdIsUnique>();
            services.AddScoped<ICheckIfFlashcardIsUnique, CheckIfFlashcardIsUnique>();
            services.AddScoped<IInsertNewFlashcard, InsertNewFlashcard>();
            services.AddScoped<IValidateFlashcard, ValidateFlashcard>();
            services.AddScoped<IUpdateFlashcardWords, UpdateFlashcardWords>();
            services.AddScoped<IUpdateFlashcard, UpdateFlashcard>();
            services.AddScoped<IDeleteFlashcard, DeleteFlashcard>();

            services.AddScoped<ILoadFiveFlashcardsForLearnWherUserId, LoadFiveFlashcardsForLearnWherUserId>();
            services.AddScoped<ILoadFiveFlashcardsForPracticeWhereUserId, LoadFiveFlashcardsForPracticeWhereUserId>();

            services.AddScoped<IReCalculateAndUpdatePracticePropertiesList, ReCalculateAndUpdatePracticePropertiesList>();
            services.AddScoped<IReCalculateFlashcardPracticeProps, ReCalculateFlashcardPracticeProps>();
            services.AddScoped<IUpdateFlashcardsListPracticeProperties, UpdateFlashcardsListPracticeProperties>();
            services.AddScoped<ICalculateNextPracticeDate, CalculateNextPracticeDate>();
            services.AddScoped<IUpdateFlashcardPracticeProperties, UpdateFlashcardPracticeProperties>();

            services.AddScoped<ICalculateIntervalsForHowManyFlashcards, CalculateIntervalsForHowManyFlashcards>();
            services.AddScoped<ICountHowManyFlashcardsForLearnWhereUserId, CountHowManyFlashcardsForLearnWhereUserId>();
            services.AddScoped<ICountHowManyFlashcardsForPracticeWhereUserId, CountHowManyFlashcardsForPracticeWhereUserId>();
        }
    }
}
