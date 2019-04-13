using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.PackageItems
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
        ViewData["DbObjectTypeId"] = new SelectList(_context.DbObjType, "Id", "Id");
        ViewData["PackageId"] = new SelectList(_context.Package, "Id", "Id");
        ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public DbObject DbObject { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DbObject.Add(DbObject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}