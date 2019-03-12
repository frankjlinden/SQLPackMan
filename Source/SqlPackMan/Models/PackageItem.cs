using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class PackageItem
    {
        public int ID { get; set; }
        public int PackageId { get; set; }
        public string DbObjectName { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        public Lists.DbObjectType DbObjectType { get; set; }
        public int StepNumber { get; set; }


    }
}
