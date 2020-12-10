using DatabaseModule;
using System.Linq;

namespace XDatabaseForXUnitTests
{
    public class ResetTestDatabase
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

                DatabaseModels databaseModels = new DatabaseModels();

                db.GroupDbModels.AddRange(databaseModels.GetGroupDbModels());
                db.FlashcardsDbModels.AddRange(databaseModels.GetFlashcardDbModels());

                db.SaveChanges();
            }
        }
    }
}
