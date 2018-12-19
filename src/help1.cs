using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace lab2
{
    public class nomer
    {
        public number[] nomera { get; set; }
    }
    public class uslug
    {
        public number[] uslugi { get; set; }
    }
    public class number
    {
        public string Type { get; set; }
        public int Price { get; set; }
    }
} 