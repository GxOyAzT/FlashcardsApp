using DatabaseModuleInterface;
using Models;

namespace DatabaseModule
{
    public class InsertNewFlashcard : IInsertNewFlashcard
    {
        public void Insert(FlashcardDbModel flashcardDbModel)
        {
            using (var db = new FlashcardsDbContext())
            {
                db.FlashcardsDbModels.Add(flashcardDbModel);
                db.SaveChanges();
            }
        }
    }
}
