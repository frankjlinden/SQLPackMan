using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Enums
{
    public enum DbObjectType
    {
        Table,
        View,
        StoredProcedure,
        Function,
        Schema,
        Sequence
    }
}
