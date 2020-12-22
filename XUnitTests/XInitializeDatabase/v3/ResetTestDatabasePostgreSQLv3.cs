﻿using DatabaseModulePostgreSQL;
using System.Linq;

namespace XUnitTests
{
    public class ResetTestDatabasePostgreSQLv3
    {
        public static void Reset()
        {
            using (var db = new FlashcardDbContextPostgreSQL())
            {
                var flashcards = db.FlashcardsDbModels.ToList();
                var groups = db.GroupDbModels.ToList();

                db.FlashcardsDbModels.RemoveRange(flashcards);
                db.GroupDbModels.RemoveRange(groups);

                db.SaveChanges();

                DatabaseModelsv3 databaseModels = new DatabaseModelsv3();

                db.GroupDbModels.AddRange(databaseModels.GetGroupDbModels());
                db.FlashcardsDbModels.AddRange(databaseModels.GetFlashcardDbModels());

                db.SaveChanges();
            }
        }
    }
}
