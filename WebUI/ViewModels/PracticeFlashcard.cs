using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI
{
    public class PracticeFlashcard
    {
        public string Id { get; set; }
        public int PracticeDirection { get; set; }
        public string Foreign { get; set; }
        public string Native { get; set; }
        public int Progress { get; set; }
    }
}
