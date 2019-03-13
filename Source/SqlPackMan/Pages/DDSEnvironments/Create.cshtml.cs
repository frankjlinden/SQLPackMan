using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.DDSEnvironments
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
        public DDSEnvironment DDSEnvironment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DDSEnvironment.Add(DDSEnvironment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}