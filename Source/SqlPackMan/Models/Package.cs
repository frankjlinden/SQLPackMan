using SqlPackMan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class Package
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentEnvironment { get; set; }
        public int MaxEnvironment { get; set; }
        public PackageStatus Status { get; set; }
        public DateTime StatusDate { get; set; }
        public string ScriptPre { get; set; }
        public string ScriptPost { get; set; }
        List<PackageItem> Items { get; set; }
        public string ScriptItems { get; set; }
        public int StepNumber { get; set; }
        public string Version { get; set; }
       


    }
}
