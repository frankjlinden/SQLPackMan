using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.Environments
{
    public class DetailsModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public DetailsModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

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
    }
}
