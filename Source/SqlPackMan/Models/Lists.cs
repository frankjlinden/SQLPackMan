﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public static class Lists
    {
        public enum DbObjectType
        {
            [Description("Table")]
            Table=0,
            View,
            StoredProcedure,
            Function,
            Schema,
            Sequence
        };
        public enum Database
        {
            Camris,
            IP6,
            LON,
            WaitList,
            WebResDay
        };
        public enum PackageStatus
        {
            AdminReview,
            Current,
            Development,
            Queued,
            Test,
            Error
        };
        public enum MigrationStatus
        {
            Error,
            Queued,
            Success
        }
    }
}