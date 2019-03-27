using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class DbObjectType
    {
        public int Id { get; set; }
        public string SqlType { get; set; }
        public string RGType { get; set; }
        public int MyProperty { get; set; }

    }
}
