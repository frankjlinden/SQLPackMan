using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class MigrationResult
    {
        public int Id { get; set; }
        public int MigrationId { get; set; }
        public string Step { get; set; }
        public DateTime Timestamp { get; set; }
        public string ResultText { get; set; }
        public int MigrationStatus { get; set; }
        public Migration Migration { get; set; }

       //result text - not configured, error, success
    }
}
