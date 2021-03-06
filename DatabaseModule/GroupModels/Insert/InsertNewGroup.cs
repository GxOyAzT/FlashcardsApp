﻿using DatabaseModuleInterface;
using Models;

namespace DatabaseModule
{
    public class InsertNewGroup : IInsertNewGroup
    {
        public void Insert(GroupDbModel groupDbModel)
        {
            using (var db = new FlashcardsDbContext())
            {
                db.GroupDbModels.Add(groupDbModel);
                db.SaveChanges();
            }
        }
    }
}
