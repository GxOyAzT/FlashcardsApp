using DatabaseModule;
using System.Linq;

namespace XDatabaseForXUnitTests
{
    public class ResetTestDatabasev2
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

                DatabaseModelsv2 databaseModels = new DatabaseModelsv2();

                db.GroupDbModels.AddRange(databaseModels.GetGroupDbModels());
                db.FlashcardsDbModels.AddRange(databaseModels.GetFlashcardDbModels());

                db.SaveChanges();
            }
        }
    }
}
