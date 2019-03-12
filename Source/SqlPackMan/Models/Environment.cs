using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class Environment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Connection { get; set; }
        public int SourceDb { get; set;}
        public int TargetDb{ get; set; }
    }
}
