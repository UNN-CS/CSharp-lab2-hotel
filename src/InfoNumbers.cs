using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab2
{
    public class InfoNumbers
    {
        public Cnumber[] numbers { get; set; }

    }

    public class InfoServices
    {
        public Cnumber[] services { get; set; }
    }

    public class Cnumber
    {
        public string Type { get; set; }
        public int Price { get; set; }
    }
}
