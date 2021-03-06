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
        public SelectList IndentingDeptOptions { get; set; }
        public SelectList TypeOptions { get; set; }
        public SelectList ModeOfTender { get; set; }
        public SelectList TypeOfBiddingOptions { get; set; }
        public SelectList ProposalForApprovalOptions { get; set; }
        public SelectList BudgetProvisionOptions { get; set; }

        [BindProperty]
        public string[] ProposalOptions { get; set; }

        [BindProperty]
        public CreateNotesheetCommand Notesheet { get; set; }

        public void OnGet()
        {
            InitSelectListItems();
            Notesheet = new() { BillOfQuantity = "Detailed BoQ is attached in Annexure I", BudgetOfferDate = DateTime.Now };
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            InitSelectListItems();
            Notesheet.ProposalOptions = ProposalOptions;
            ValidationResult validationCheck = new CreateNotesheetCommandValidator().Validate(Notesheet);
            validationCheck.AddToModelState(ModelState, nameof(Notesheet));
            // create new order
            if (Notesheet.ModeOfTerm == "Limited Tender (Paper based)" || Notesheet.ModeOfTerm == "CPP Portal LTE")
            {
                if (Notesheet.ListOfParties == null)
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
        public void InitSelectListItems()
        {
            TypeOptions = new SelectList(TypeConstants.GetTypesOptions());
            ModeOfTender = new SelectList(ModeOfTenderConstants.GetModeOfTenderOptions());
            //TypeOfBiddingOptions = new SelectList(TypeOfBiddingConstants.GetTypeOfBiddingOptions());
            BudgetProvisionOptions = new SelectList(BudgetProvisionConstants.GetBudgetProvisionOptions());
            ProposalForApprovalOptions = new SelectList(ProposalForApprovalConstants.GetProposalForApprovalOptions());
            IndentingDeptOptions = new SelectList(IndentingDeptConstants.GetIndentingDeptOptions());
        }
    }
}
