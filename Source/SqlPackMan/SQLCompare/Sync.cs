﻿using SqlPackMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.SQLCompare
{
    public class Sync
    {
        public void BeforeRefresh(DdsDatabase database, DdsEnvironment environment, string scriptsFolder)
        {

        }
        public void AfterRefresh(DdsDatabase database, DdsEnvironment environment, string scriptsFolder)
        {

        }
        public Migration CommitMigration (Migration migration){
            return new Migration();
        }
    }
}
