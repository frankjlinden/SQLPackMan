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
    public class DeleteModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public DeleteModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Migration = await _context.Migration.FindAsync(id);

            if (Migration != null)
            {
                _context.Migration.Remove(Migration);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
