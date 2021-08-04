using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;

namespace WebApp.Pages.Notesheets
{
    public class EditModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public EditModel(Infra.Persistence.AppDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notesheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesheetExists(Notesheet.Id))
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

        private bool NotesheetExists(int id)
        {
            return _context.Notesheets.Any(e => e.Id == id);
        }
    }
}
