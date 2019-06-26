using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class DbObjectName
    {
        [Key]
        public string Name { get; set; }
        public int? PackageId { get; set; }

        [NotMapped]
        public bool Selected
        {
            get => (PackageId != null);
            set => Selected = value;
        }
    }
}
