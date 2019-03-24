
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class Migration
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string PreScript { get; set; }
        public string PostScript { get; set; }
        public string PackageScript { get; set; }
    
        public int DDSDatabase { get; set; }
      
        public int TargetEnvironment  { get; set; }

        // nav props
        public DDSDatabase Database { get; set; }
        public DdsEnvironment   Environment { get; set; }
        public StatusCode Status { get; set; }
        public List<MigrationResult> MigrationResults { get; set; }

        //status Error, Success

    }
}
