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
    public class DetailsModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public DetailsModel(Infra.Persistence.AppDbContext context)
        {
            _context = context;
        }
        public ICollection<ProposalForApproval> ProposalForApprovals { get; set; }
        public Notesheet Notesheet { get; set; }
        public string Date { get; set; }
        public string BudgetOfferDate { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // create child entities for each proposal options

            Notesheet = await _context.Notesheets.Where(m => m.Id == id)
                                        .Include(n => n.ProposalForApprovals)
                                        .FirstOrDefaultAsync();
            
            Date = Notesheet.Created.ToString("dd-MM-yyyy");
            BudgetOfferDate = Notesheet.BudgetOfferDate.ToString("dd-MM-yyyy");

            if (Notesheet == null)
            {
                return NotFound();
            }
            ProposalForApprovals = Notesheet.ProposalForApprovals;
            return Page();
        }
    }
}
