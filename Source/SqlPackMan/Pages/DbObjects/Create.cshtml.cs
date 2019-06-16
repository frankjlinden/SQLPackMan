using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.DbObjects
{
    public class CreateModel : DbObjectCreateEditPageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;
        private int? CurrentPackageId;
        private string CurrentPackageName;
        private string CurrentDBName;

        public string NameSort { get; set; }
        public string TypeSort { get; set; }

        /// <summary>
        /// NameFilter provides the Razor Page with the current filter string. The NameFilter value:
        /// Must be included in the paging links in order to maintain the filter settings during paging.
        /// Must be restored to the text box when the page is redisplayed.
        /// </summary>
        public string CurrentFilterName { get; set; }
        public string CurrentFilterType { get; set; }

        public PaginatedList<DbObject> DbObjects { get; set; }
        /// <summary>
        /// provides the Razor Page with the current sort order. The current sort order must be included in the paging links to keep the sort order while paging.
        /// </summary>
        public string CurrentSort { get; set; }
        public CreateModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }
       
        public IActionResult OnGetAsync(int packageId, string packageName, string sortOrder, string searchStringType, string searchStringName, int? pageIndex)
        {
                CurrentPackageId = packageId;
            if (packageName != null)
                CurrentPackageName = packageName;
            if (searchStringType != null)
                CurrentFilterType = searchStringType;
            if (searchStringName != null)
                CurrentFilterName = searchStringName;


            //First time model will come back null. Set it now to name_desc so that will be the value that comes back when they click the sort header.
            // When it comes back next time with a value, set it to empty string and toggle the functionality again the next time when empty string comes back from client. 
            PopulateDbObjectTypeSelectList(_context);
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            TypeSort = sortOrder == "Type" ? "type_desc" : "Type";
            return Page();
            
        }

        [BindProperty]
        public DbObject DbObject { get; set; }

       
    }
}