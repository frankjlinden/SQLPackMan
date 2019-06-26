using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Models
{
    public static class Enums
    {
        public enum DbObjectType
        {
            [Description("U")]
            Table = 0,

            [Description("V")]
            View = 1,

            [Description("P")]
            StoredProcedure = 2,

            [Description("FN,FT,IF")]  
            Function=3,

            [Description("SQ")]
            Sequence =4
        };


        public enum Status
        {
            Development,
            AdminReview,
            Queued,
            Test,
            Current,
            Error,
            Success
        };

    }
}
