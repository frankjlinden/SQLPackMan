using Microsoft.AspNetCore.Mvc.Rendering;
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
            [Description("U")]
            Table = 0,

            [Description("V")]
            View = 1,

            [Description("P")]
            StoredProcedure = 2,

            [Description("FN,FT,IF")]  // Where 
            Function=3,

            [Description("Sequence")]
            SQ =4,

            [Description("Schema")] // sys.schema
            Schema=5,

           
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
