using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;

namespace WebApp.Pages.ProposalForApprovals
{
    public class DeleteModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public DeleteModel(Infra.Persistence.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProposalForApproval ProposalForApproval { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProposalForApproval = await _context.ProposalForApprovals
                .Include(p => p.Notesheet).FirstOrDefaultAsync(m => m.Id == id);

            if (ProposalForApproval == null)
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

            ProposalForApproval = await _context.ProposalForApprovals.FindAsync(id);

            if (ProposalForApproval != null)
            {
                _context.ProposalForApprovals.Remove(ProposalForApproval);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Notesheets/Edit", new { id = ProposalForApproval.NotesheetId});
        }
    }
}
