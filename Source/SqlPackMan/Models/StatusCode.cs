using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class StatusCode
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Label { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsItemLevel { get; set; }
    }

}
