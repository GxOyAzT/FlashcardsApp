using DatabaseModuleInterface;
using Models;

namespace DatabaseModulePostgreSQL
{
    public class InsertNewFlashcardPostgreSQL : IInsertNewFlashcard
    {
        public void Insert(FlashcardDbModel flashcardDbModel)
        {
            using (var db = new FlashcardDbContextPostgreSQL())
            {
                db.FlashcardsDbModels.Add(flashcardDbModel);
                db.SaveChanges();
            }
        }

    }
}
