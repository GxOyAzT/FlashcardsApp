﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GroupDbModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<FlashcardDbModel> FlashcardDbModels { get; set; }
    }
}
