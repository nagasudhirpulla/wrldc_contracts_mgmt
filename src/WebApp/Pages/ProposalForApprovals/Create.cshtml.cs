using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Entities;
using Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Notesheets;

namespace WebApp.Pages.ProposalForApprovals
{
    public class CreateModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public SelectList ProposalForApprovalOptions { get; set; }

        [BindProperty]
        public ProposalForApproval ProposalForApproval { get; set; }
        [BindProperty]
        public string ProposalForApprovalOthersOption { get; set; }

        public CreateModel(Infra.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? nid)
        {
            if (nid == null)
            {
                return NotFound();
            }

            Notesheet notesht = await _context.Notesheets.Where(n => n.Id == nid)
                                        .Include(n => n.ProposalForApprovals)
                                        .FirstOrDefaultAsync();
            if (notesht == null)
            {
                return NotFound();
            }
            ProposalForApproval = new ProposalForApproval()
            {
                NotesheetId = nid.Value
            };
            InitSelectListItems(notesht.ProposalForApprovals);
            return Page();
        }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Notesheet notesht = await _context.Notesheets.Where(n => n.Id == ProposalForApproval.NotesheetId)
                                        .Include(n => n.ProposalForApprovals)
                                        .FirstOrDefaultAsync();
                InitSelectListItems(notesht.ProposalForApprovals);
                return Page();
            }

            string pOptTxt = ProposalForApproval.ProposalOption;
            if (pOptTxt.ToLower() == "others")
            {
                pOptTxt = "";
                string otherOPtionTxt = ProposalForApprovalOthersOption;
                if (!String.IsNullOrWhiteSpace(otherOPtionTxt))
                {
                    otherOPtionTxt = otherOPtionTxt.Trim();
                    if (otherOPtionTxt.ToLower() != "others")
                    {
                        pOptTxt = otherOPtionTxt;
                    }
                }
                ProposalForApproval.ProposalOption = pOptTxt;
            }
            if (!string.IsNullOrWhiteSpace(pOptTxt))
            {
                _context.ProposalForApprovals.Add(ProposalForApproval);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Notesheets/Edit", new { id = ProposalForApproval.NotesheetId });
        }



        public void InitSelectListItems(ICollection<ProposalForApproval> existingNotesheetPropForApproval)
        {
            var allProposalForApprovalOptions = ProposalForApprovalConstants.GetProposalForApprovalOptions();
            var existingProposalForApprovalOptions = existingNotesheetPropForApproval
                                                    .Select(x => x.ProposalOption.ToString())
                                                    .ToList();
            var optionsForPage = allProposalForApprovalOptions.Where(op => !existingProposalForApprovalOptions.Contains(op));
            ProposalForApprovalOptions = new SelectList(optionsForPage);
        }
    }
}
