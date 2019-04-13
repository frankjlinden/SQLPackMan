using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.Environments
{
    public class EditModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public EditModel(SqlPackMan.Models.SqlPackManContext context)
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

            DdsEnvironment = await _context.DdsEnvironment.FirstOrDefaultAsync(m => m.Id == id);

            if (DdsEnvironment == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DdsEnvironment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DdsEnvironmentExists(DdsEnvironment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DdsEnvironmentExists(int id)
        {
            return _context.DdsEnvironment.Any(e => e.Id == id);
        }
    }
}
