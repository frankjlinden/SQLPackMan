using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.DbObjects
{
    public class EditModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public EditModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DbObject DbObject { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DbObject = await _context.DbObject
                .Include(d => d.DbObjectType)
                .Include(d => d.Package)
                .Include(d => d.Status).FirstOrDefaultAsync(m => m.Id == id);

            if (DbObject == null)
            {
                return NotFound();
            }
           ViewData["DbObjectTypeId"] = new SelectList(_context.DbObjType, "Id", "Id");
           ViewData["PackageId"] = new SelectList(_context.Package, "Id", "Id");
           ViewData["StatusId"] = new SelectList(_context.Status, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DbObject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbObjectExists(DbObject.Id))
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

        private bool DbObjectExists(int id)
        {
            return _context.DbObject.Any(e => e.Id == id);
        }
    }
}
