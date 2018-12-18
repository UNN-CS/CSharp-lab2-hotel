using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class NNumbers
    {
        public Num[] num { get; set; }
    }
    public class Servies
    {
        public Num[] servies { get; set; }
    }
    public class Num
    {
        public string Type { get; set; }
        public int Price { get; set; }
    }
}
