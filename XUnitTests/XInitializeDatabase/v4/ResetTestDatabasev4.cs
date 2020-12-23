using DatabaseModule;
using System.Linq;

namespace XUnitTests
{
    public class ResetTestDatabasev4
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

                DatabaseModelsv4 databaseModels = new DatabaseModelsv4();

                db.GroupDbModels.AddRange(databaseModels.GetGroupDbModels());
                db.FlashcardsDbModels.AddRange(databaseModels.GetFlashcardDbModels());

                db.SaveChanges();
            }
        }
    }
}
