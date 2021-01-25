using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModuleInterface
{
    public interface ICountNewFlashcardsWhereUserId
    {
        public int Count(string userId);
    }
}
