using SqlPackMan.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class Package
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int DDSEnvironmentId { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public Lists.Database Database { get; set; }

        public int MaxEnvironment { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public Lists.PackageStatus PackageStatus { get; set; }
        public DateTime StatusDate { get; set; }
        public string ScriptPre { get; set; }
        public string ScriptPost { get; set; }
        List<PackageItem> Items { get; set; }
        public string ScriptItems { get; set; }
        public int StepNumber { get; set; }
        public string Version { get; set; }
       


    }
}
