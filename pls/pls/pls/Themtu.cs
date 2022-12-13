using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pls
{
    public class Themtu
    {
        public string Anh { get; set; }
        public string Viet { get; set;}
        public override string ToString()
        {
            return Anh + "  " + Viet;
        }
    }
}
