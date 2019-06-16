using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlPackMan.Models;

namespace SqlPackMan.Pages.DbObjects
{
    public class DetailsModel : PageModel
    {
        private readonly SqlPackMan.Models.SqlPackManContext _context;

        public DetailsModel(SqlPackMan.Models.SqlPackManContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
