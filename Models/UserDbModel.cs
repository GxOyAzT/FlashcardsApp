using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class UserDbModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public bool IsAccountConfirmed { get; set; }
        
        public virtual ICollection<GroupDbModel> GroupDbModels { get; set; }
    }
}
