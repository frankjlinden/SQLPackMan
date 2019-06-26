
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static SqlPackMan.Models.Enums;

namespace SqlPackMan.Models
{
    public class Package
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        [DisplayName("Package Name")]
        public string Name { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
        
        private int _statusId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Status Date")]
        public DateTime StatusDate { get; set; }
            
        public int CurEnvironmentId { get; set; }

        [StringLength(50)]
        [DisplayName("Database")]
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
        public Status Status
        {
            get => (Status)_statusId;
            set => _statusId = (int)value;
        }
        public ICollection<DbObject> Items { get; set; }
        public ICollection<Migration> Migrations { get; set; }

        public Package()
        {
            Version = 1;
            CurEnvironmentId = 1;
            MaxEnvironmentId = 1;
        }
    }
}
