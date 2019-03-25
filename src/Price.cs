using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab2
{
    public class Appartment
    {
        public number[] Appartments { get; set; }
    }
    public class Extra
    {
        public number[] Extras { get; set; }
    }
    public class number
    {
        public string Type { get; set; }
        public int Price { get; set; }
    }
}