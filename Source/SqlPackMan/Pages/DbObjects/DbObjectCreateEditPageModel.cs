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
        private readonly SqlPackManContext _context;
        public IQueryable<DbObject> iQDbObject;
        public SelectList DbObjectTypeSL { get; set; }

        public void SearchDbObjects(string db, string type, string name ) {
            //try
            //{
            //    var devEnv = _context.DdsEnvironment.FirstOrDefault(e => e.Name == "DEV");
            //    var dbAdo = new DbObjectDAL(devEnv.Server);
            //    var repo = new DbObject
            //    iQDbObject = dbAdo.DbNames(db,type,name).AsQueryable();
            //}
            //catch (Exception e)
            //{
            //    throw (e);
            //}

        }
    }
}
