using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.Packages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public IndexModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        public IList<Package> Package { get;set; }

        public async Task OnGetAsync()
        {
            Package = await _context.Package.ToListAsync();

            //Package = Package.Where(p => p.Status.Equals(Lists.Status.AdminReview)
            //                                                    || p.Status.Equals(Lists.Status.Queued)
            //                                                    || p.Status.Equals(Lists.Status.Error)
            //                                                       ).ToList();
        }
    }
}
