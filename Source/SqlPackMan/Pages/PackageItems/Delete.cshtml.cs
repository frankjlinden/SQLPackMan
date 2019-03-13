using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.PackageItems
{
    public class DeleteModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public DeleteModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PackageItem PackageItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PackageItem = await _context.PackageItem.FirstOrDefaultAsync(m => m.ID == id);

            if (PackageItem == null)
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

            PackageItem = await _context.PackageItem.FindAsync(id);

            if (PackageItem != null)
            {
                _context.PackageItem.Remove(PackageItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
