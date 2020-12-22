using DatabaseModuleInterface;
using System;
using System.Linq;

namespace DatabaseModule
{
    public class DeleteGroup : IDeleteGroup
    {
        public void Delete(Guid groupId)
        {
            using (var db = new FlashcardsDbContext())
            {
                var groupModel = db.GroupDbModels.FirstOrDefault(e => e.Id == groupId);

                if (groupModel == null)
                    return;

                var groupFlashcards = db.FlashcardsDbModels.Where(e => e.GroupDbModelId == groupId).ToList();

                foreach(var item in groupFlashcards)
                {
                    db.FlashcardsDbModels.Remove(item);
                }

                db.GroupDbModels.Remove(groupModel);

                db.SaveChanges();
            }
        }
    }
}
