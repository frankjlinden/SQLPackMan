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
    public class DetailsModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public DetailsModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

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
    }
}
