using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;

namespace WebApp.Pages.Notesheets
{
    public class DeleteModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public DeleteModel(Infra.Persistence.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notesheet Notesheet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notesheet = await _context.Notesheets.FirstOrDefaultAsync(m => m.Id == id);

            if (Notesheet == null)
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

            Notesheet = await _context.Notesheets.FindAsync(id);

            if (Notesheet != null)
            {
                _context.Notesheets.Remove(Notesheet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
