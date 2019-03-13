using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.DDSEnvironments
{
    public class DeleteModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public DeleteModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DDSEnvironment DDSEnvironment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DDSEnvironment = await _context.DDSEnvironment.FirstOrDefaultAsync(m => m.ID == id);

            if (DDSEnvironment == null)
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

            DDSEnvironment = await _context.DDSEnvironment.FindAsync(id);

            if (DDSEnvironment != null)
            {
                _context.DDSEnvironment.Remove(DDSEnvironment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
