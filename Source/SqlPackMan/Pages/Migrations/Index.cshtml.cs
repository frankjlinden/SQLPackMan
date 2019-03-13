using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.Migrations
{
    public class IndexModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public IndexModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        public IList<Migration> Migration { get;set; }

        public async Task OnGetAsync()
        {
            Migration = await _context.Migration.ToListAsync();
        }
    }
}
