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
        public enum ItemType
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
            SQ =4
        };
      
        public enum Status
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
        };
       

    }
}
