using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlPackMan.Pages.DbObjects
{
    public class DbObjectCreateEditPageModel : PageModel
    {
        public SelectList DbObjectTypeSL { get; set; }

        public void PopulateDbObjectTypeSelectList(SqlPackManContext context, object selectedObjectType = null)
        {
            var dbObjectTypeQuery = from ot in context.DbObjType
                              select ot;

            DbObjectTypeSL = new SelectList(dbObjectTypeQuery.AsNoTracking(),  "SqlType", "RGType", selectedObjectType);
        }

    }
}
