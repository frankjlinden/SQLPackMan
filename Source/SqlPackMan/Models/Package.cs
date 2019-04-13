
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class Package
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }

        
        public int StatusId { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StatusDate { get; set; }
        public int CurEnvironmentId { get; set; }

        [StringLength(50)]
        public string DbName { get; set; }

       
        public int MaxEnvironmentId { get; set; }
        public int Version { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        //nav props 
        [DisplayName("Cur Env")]
        public DdsEnvironment CurEnvironment { get; set; }

        [DisplayName("Max Env")]
        public DdsEnvironment MaxEnvironment { get; set; }
        public Status Status { get; set; }
        public ICollection<DbObject> Items { get; set; }
        public ICollection<Migration> Migrations { get; set; }

    }
}
