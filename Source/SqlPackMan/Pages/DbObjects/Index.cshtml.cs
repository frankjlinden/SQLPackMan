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

namespace SqlPackMan.Pages.DbObjects
{
    public class IndexModel : DbObjectCreateEditPageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public IndexModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string TypeSort { get; set; }
       
        /// <summary>
        /// NameFilter provides the Razor Page with the current filter string. The NameFilter value:
        /// Must be included in the paging links in order to maintain the filter settings during paging.
        /// Must be restored to the text box when the page is redisplayed.
        /// </summary>
        public string CurrentFilterName { get; set; }

        [BindProperty]
        public string CurrentFilterType { get; set; }
        public string SearchStringName { get; set; }
        [BindProperty]
        public string SearchStringType { get; set; }

        /// <summary>
        /// provides the Razor Page with the current sort order. The current sort order must be included in the paging links to keep the sort order while paging.
        /// </summary>
        public string CurrentSort { get; set; }


        public PaginatedList<DbObject> DbObjects { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilterType, string currentFilterName, string searchStringType, string searchStringName, int? pageIndex)
        {
            //First time model will come back null. Set it now to name_desc so that will be the value that comes back when they click the sort header.
            // When it comes back next time with a value, set it to empty string and toggle the functionality again the next time when empty string comes back from client. 
            PopulateDbObjectTypeSelectList(_context);
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";

            //If the search string is changed while paging, the page is reset to 1. 
            //The page has to be reset to 1 because the new filter can result in different data to display. 
            //When a search value is entered and Submit is selected:


            // If the Name search string is changed.
            //The searchStringType parameter isn't null.
            if (searchStringType != null)
            {
                pageIndex = 1;
                
            }
            else
            {
                searchStringType = currentFilterType;
            }

            // set current filterType
            CurrentFilterType = searchStringType;


            // If the Name search string is changed.
            //The searchStringName parameter isn't null.
            if (searchStringName != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchStringName = currentFilterName;
            }

            // set current filter for Name 
            CurrentFilterName = searchStringName;

            var dbObjectIQ = from o in _context.DbObject
                                              select o;
            //todo create iqueryable using dbObjectDAL


            // if (!String.IsNullOrEmpty(searchStringDB))
            //{
            //    dbObjectIQ = dbObjectIQ.Where(p => p.ObjectName.Any(db));
            //}

            if (!String.IsNullOrEmpty(searchStringName))
            {
                dbObjectIQ = dbObjectIQ.Where(p => p.ObjectName.Contains(searchStringName));


                switch (sortOrder)
                {
                    case "name_desc":
                        dbObjectIQ = dbObjectIQ.OrderByDescending(p => p.ObjectName);
                        break;
                    case "Status":
                        dbObjectIQ = dbObjectIQ.OrderBy(p => p.Status.Label);
                        break;
                    case "status_desc":
                        dbObjectIQ = dbObjectIQ.OrderByDescending(p => p.Status.Label);
                        break;
                }
                int pageSize = 4;

                DbObjects = await PaginatedList<DbObject>.CreateAsync(dbObjectIQ.AsNoTracking().Include(p => p.Status)
                  , pageIndex ?? 1, pageSize);
            }
        }

    }
}
