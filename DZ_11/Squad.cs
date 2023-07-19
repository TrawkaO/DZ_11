using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DZ_11.Program;

namespace DZ_11
{
    internal class Squad
    {
        public string squadName { get; set; }
        public string homeTown { get; set; }
        public int formed { get; set; }
        public string secretBase { get; set; }
        public bool active { get; set; }
        public Hero[] members { get; set; }
    }
}
