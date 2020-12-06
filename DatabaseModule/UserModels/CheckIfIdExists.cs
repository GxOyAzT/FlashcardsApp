using DatabaseModuleInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseModule
{
    public class CheckIfIdExists : ICheckIfIdExists
    {
        public bool Check(Guid newId)
        {
            using (var db = new FlashcardsDbContext()) 
            {
                return db.UserDbModels.FirstOrDefault(e => e.Id == newId) != null;
            }
        }
    }
}
