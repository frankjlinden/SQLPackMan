using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class PackageItem
    {
        private string _tags;

        public int Id { get; set; }
        public string DbObjectName { get; set; }
        public int PackageId { get; set; }
        public int StatusId { get; set; }
        public int DbObjectTypeId { get; set; }
        

        [NotMapped]
        public HashSet<string> Tags;

        //nav props
        public Package Package { get; set; }
        public DbObjectType DbObjectType { get; set; }
        public StatusCode Status { get; set; }

    }
}
