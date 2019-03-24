using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.DdsEnvironments
{
    public class DeleteModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public DeleteModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DdsEnvironment DdsEnvironment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DdsEnvironment = await _context.DdsEnvironment.FirstOrDefaultAsync(m => m.ID == id);

            if (DdsEnvironment == null)
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

            DdsEnvironment = await _context.DdsEnvironment.FindAsync(id);

            if (DdsEnvironment != null)
            {
                _context.DdsEnvironment.Remove(DdsEnvironment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
