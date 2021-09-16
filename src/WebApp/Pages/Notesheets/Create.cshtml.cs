using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Entities;
using Infra.Persistence;
using Application.Notesheets.Commands.CreateNotesheet;
using MediatR;
using Application.Notesheets;
using FluentValidation.Results;
using FluentValidation.AspNetCore;

namespace WebApp.Pages.Notesheets
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public SelectList TypeOptions { get; set; }
        public SelectList ModeOfTender { get; set; }
        public SelectList TypeOfBiddingOptions{get;set;}
        public SelectList ProposalForApprovalOptions { get; set; }
        public SelectList BudgetProvisionOptions { get; set; }

        [BindProperty]
        public string[] ProposalOptions { get; set; }

        [BindProperty]
        public CreateNotesheetCommand Notesheet { get; set; }

        public async Task OnGetAsync()
        {
            await InitSelectListItems();
            //Notesheet.BillOfQuantity = "Detailed BBQ attached in Annexure I";
            //return Page();
            Notesheet = new() { BillOfQuantity= "Detailed BoQ is attached in Annexure I" };
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await InitSelectListItems();
            Notesheet.ProposalOptions = ProposalOptions;
            ValidationResult validationCheck = new CreateNotesheetCommandValidator().Validate(Notesheet);
            validationCheck.AddToModelState(ModelState, nameof(Notesheet));
            // create new order
            if (Notesheet.ModeOfTerm == "Open Tender (Paper based)")
            {
                if (Notesheet.ListOfParties==null)
                {
                    string Error = "List of party cant be empty";
                    ModelState.AddModelError(string.Empty, Error);
                }
            }

            if (ModelState.IsValid)
            {
                List<string> errors = await _mediator.Send(Notesheet);

                if (errors.Count == 0)
                {

                    return RedirectToPage("./Index");
                }

                foreach (var err in errors)
                {
                    ModelState.AddModelError(string.Empty, err);
                }
            }
                return Page();
            

            
        }
        public async Task InitSelectListItems()
        {
            
            TypeOptions = new SelectList(TypeConstants.GetTypesOptions());
            ModeOfTender = new SelectList(ModeOfTenderConstants.GetModeOfTenderOptions());
            //TypeOfBiddingOptions = new SelectList(TypeOfBiddingConstants.GetTypeOfBiddingOptions());
            BudgetProvisionOptions = new SelectList(BudgetProvisionConstants.GetBudgetProvisionOptions());
            ProposalForApprovalOptions = new SelectList(ProposalForApprovalConstants.GetProposalForApprovalOptions());
        }
    }
}
