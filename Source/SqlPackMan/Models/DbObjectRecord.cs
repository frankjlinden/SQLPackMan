using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class DbObjectRecord
    {
        public string DbObjectName { get; set; }
        public string   SQLType { get; set; }
        public string RGType { get; set; }
    }
}
