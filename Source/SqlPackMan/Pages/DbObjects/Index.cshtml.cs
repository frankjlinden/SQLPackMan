using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;
using SqlPackMan.Pages.DbObjects;
using SqlPackMan.Data;

namespace SqlPackMan.Pages.DbObjects
{
    public class IndexModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;
        private  DbObjectSqlRepo _dbObjectRepo;

        public IndexModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
            _dbObjectRepo = new DbObjectSqlRepo(_context);
        }
        public IQueryable<string> dbObjectNameIQ;
        public string NameSort { get; set; }
        public string TypeSort { get; set; }
        public int? SearchIntType { get; set; }
        /// <summary>
        /// NameFilter provides the Razor Page with the current filter string. The NameFilter value:
        /// Must be included in the paging links in order to maintain the filter settings during paging.
        /// Must be restored to the text box when the page is redisplayed.
        /// </summary>
        
        public string CurrentFilterName { get; set; }

        public int CurrentPackageId { get; set; }

        [BindProperty]
        public string CurrentFilterDB { get; set; }

        [BindProperty]
        public Package Package { get; set; }

        [BindProperty]
        public string CurrentFilterType { get; set; }

        [BindProperty]
        public DbObjectName[] DbObjNames { get; set; }
        /// <summary>
        /// provides the Razor Page with the current sort order. The current sort order must be included in the paging links to keep the sort order while paging.
        /// </summary>
        public string CurrentSort { get; set; }

        public PaginatedList<DbObjectName> Names { get; set; }

        public async Task OnGetAsync(string button, int packageId, List<string> existingNames,
                                    string sortOrder, string currentFilterDb, string dbName, int? searchIntType, string currentFilterName, string currentFilterType, string searchStringName, int? pageIndex)
        {
            if (dbName != null)
            {
                pageIndex = 1;
                CurrentFilterDB = dbName;
            }
            else
            {
                CurrentFilterDB = currentFilterDb;
            }
            if (searchStringName != null)
            {
                pageIndex = 1;
                CurrentFilterName = searchStringName;
            }
            else
            {
                CurrentFilterName = currentFilterName;
            }
            if (searchIntType != null)
            {
                pageIndex = 1;
                Enums.DbObjectType type = (Enums.DbObjectType)searchIntType;
                CurrentFilterType = type.GetDescription();
            }
            else
            {
          
                CurrentFilterType = currentFilterType;
            }
            if (packageId != null)
            {
                pageIndex = 1;
                CurrentPackageId = packageId;
            }
            else
            {
                CurrentPackageId = packageId;
            }

            //First time model will come back null. Set it now to name_desc so that will be the value that comes back when they click the sort header.
            // When it comes back next time with a value, set it to empty string and toggle the functionality again the next time when empty string comes back from client. 

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";

            //If the search string is changed while paging, the page is reset to 1. 
            //The page has to be reset to 1 because the new filter can result in different data to display. 
            //When a search value is entered and Submit is selected:

            //todo create iqueryable using dbObjectDAL
            if (button == "search")
            {
                
                try
                {
                    // var devEnv = _context.DdsEnvironment.FirstOrDefault(e => e.Name == "DEV");
                    // var dbObjectSQLDal = new DbObjectDAL(devEnv.Server);
                    // Get object name results as Iqueryable for paginated list
                    //  _dbObjectRepo = new DbObjectSqlRepo(dbObjectSQLDal);
                    // dbObjectNameIQ = _dbObjectRepo.GetDbObjNameIQ(CurrentFilterDB, CurrentFilterType, CurrentFilterName).ToList().AsQueryable();
                    var dbObjNameResult = _dbObjectRepo.GetDbObjNameIQ(CurrentFilterDB, CurrentFilterType, CurrentFilterName);
                    switch (sortOrder)
                    {
                        case "name_desc":
                            dbObjectNameIQ = dbObjectNameIQ.OrderByDescending(p=>p);
                            break;
                    }
                    int pageSize = 8;

                    Names = await PaginatedList<DbObjectName>.CreateAsync(dbObjNameResult, pageIndex ?? 1, pageSize);

                }
                catch (Exception e)
                {
                    throw (e);
                }
            }

        }

      
    }
}
