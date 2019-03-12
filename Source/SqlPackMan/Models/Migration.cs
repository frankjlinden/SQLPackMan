using SqlPackMan.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "nvarchar(24)")]
        public Lists.MigrationStatus Status { get; set; }
        public Lists.Database Database { get; set; }
        public DDSEnvironment DDSEnvironment { get; set; }


    }
}
