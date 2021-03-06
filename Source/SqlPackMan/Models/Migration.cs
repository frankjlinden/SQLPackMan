﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static SqlPackMan.Models.Enums;

namespace SqlPackMan.Models
{
    public class Migration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private int _statusId;
        public Status Status
        {
            get => (Status)_statusId;
            set => _statusId = (int)value;
        }
        public int PackageId { get; set; }

        public string PreScript { get; set; }
        public string PostScript { get; set; }
        public string PackageScript { get; set; }

        public int DdsEnvironmentId { get; set; }

        public int TargetEnvironment { get; set; }

        // nav props
        public Package Package { get; set; }
        public DdsEnvironment Environment { get; set; }
        public List<MigrationResult> MigrationResults { get; set; }

        //status Error, Success

    }
}
