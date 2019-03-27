using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class DbObject
    {
        private string _tags;

        public int Id { get; set; }
        public string ObjectName { get; set; }
        public int PackageId { get; set; }
        public string Status { get; set; }
        public int ItemTypeId { get; set; }
        

        [NotMapped]
        public HashSet<string> Tags;

        //nav props
        public Package Package { get; set; }

    }
}
