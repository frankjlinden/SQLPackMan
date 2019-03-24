using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class DdsEnvironment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string SourceControlPath{ get; set; }
        
    }
}
