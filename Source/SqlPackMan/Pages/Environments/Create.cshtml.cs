using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.Environments
{
    public class CreateModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public CreateModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DdsEnvironment DdsEnvironment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DdsEnvironment.Add(DdsEnvironment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}