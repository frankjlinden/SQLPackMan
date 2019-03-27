using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class Status
    {
        public int Code { get; set; }
        public int Label { get; set; }
        public bool IsItemLevel { get; set; }
    }
}
