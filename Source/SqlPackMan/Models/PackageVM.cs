using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models.ViewModels
{
    public class PackageVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<DbObject> DbObjects { get; set; }
        public SelectList StatusList { get; set; }
        public string PackageStatus { get; set; }

    }
}
