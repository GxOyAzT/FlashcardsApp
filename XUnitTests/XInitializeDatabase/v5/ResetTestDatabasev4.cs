using DatabaseModule;
using System.Linq;

namespace XUnitTests
{
    public class ResetTestDatabasev5
    {
        public static void Reset()
        {
            using (var db = new FlashcardsDbContext())
            { 
                var flashcards = db.FlashcardsDbModels.ToList();
                var groups = db.GroupDbModels.ToList();

                db.FlashcardsDbModels.RemoveRange(flashcards);
                db.GroupDbModels.RemoveRange(groups);

                db.SaveChanges();

                DatabaseModelsv5 databaseModels = new DatabaseModelsv5();

                db.GroupDbModels.AddRange(databaseModels.GetGroupDbModels());
                db.FlashcardsDbModels.AddRange(databaseModels.GetFlashcardDbModels());

                db.SaveChanges();
            }
        }
    }
}
