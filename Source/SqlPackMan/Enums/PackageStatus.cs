using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Enums
{
    public enum PackageStatus
    {
        AdminReview,
        Current,
        Development,
        Queued,
        Test,
        Error
    }
}
