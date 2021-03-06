﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public class MigrationResult
    {
        public int Id { get; set; }
        public int MigrationId { get; set; }
        [StringLength(50)]
        public string Step { get; set; }
        public DateTime Timestamp { get; set; }
        public string ResultText { get; set; }
        
       
        public Migration Migration { get; set; }

        //Step 1: PreScript
        //Step 2: Package Script
        //Step 3: Post Script
       //result text - not configured, error, success
    }
}
