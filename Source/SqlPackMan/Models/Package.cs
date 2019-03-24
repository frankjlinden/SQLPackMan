
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public DateTime StatusDate { get; set; }
        public int DdsEnvironmentId { get; set; }
        public string DbName { get; set; }
        public int MaxEnvironmentId { get; set; }
        
        //nav props
        public StatusCode Status { get; set; }
        public DdsEnvironment CurrentEnvironment { get;set; }
        public ICollection<PackageItem> Items { get; set; }
      
    }
}
