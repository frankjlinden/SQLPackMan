using SqlPackMan.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class Migration
    {
        public int ID { get; set; }
        public string Name { get; set; }
        List<Package> Packages { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ResultText { get; set; }
        public MigrationStatus Status { get; set; }

    }
}
