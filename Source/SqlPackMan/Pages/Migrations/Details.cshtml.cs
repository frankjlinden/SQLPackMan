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
    public class DetailsModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public DetailsModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        public Migration Migration { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Migration = await _context.Migration.FirstOrDefaultAsync(m => m.ID == id);

            if (Migration == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
