using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class DbObjectType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string SqlType { get; set; }

        [StringLength(50)]
        public string RGType { get; set; }
       

    }
}
