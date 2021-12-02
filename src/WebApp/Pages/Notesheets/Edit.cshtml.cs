﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;
using Microsoft.Extensions.Logging;
using MediatR;
using Application.Notesheets.Commands.EditNotesheet;
using Application.Notesheets.Queries.GetNotesheetById;
using AutoMapper;
using WebApp.Extensions;
using Application.Notesheets;
using FluentValidation.AspNetCore;
using FluentValidation.Results;


namespace WebApp.Pages.Notesheets
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EditModel(ILogger<EditModel> logger,
                         IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [BindProperty]
        public EditNotesheetCommand Notesheet { get; set; }
        public SelectList IndentingDeptOptions { get; set; }
        public SelectList TypeOptions { get; set; }
        public SelectList ModeOfTender { get; set; }
        public SelectList TypeOfBiddingOptions { get; set; }
        public SelectList ProposalForApprovalOptions { get; set; }
        public SelectList BudgetProvisionOptions { get; set; }

        public ICollection<ProposalForApproval> ProposalForApprovals { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Notesheet notesheet = await _mediator.Send(new GetNotesheetByIdQuery() { Id = id.Value });

            if (notesheet == null)
            {
                return NotFound();
            }

            InitSelectListItems(notesheet);

            Notesheet = _mapper.Map<EditNotesheetCommand>(notesheet);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Notesheet notesheet = await _mediator.Send(new GetNotesheetByIdQuery() { Id = Notesheet.Id });
            // validate command
            ValidationResult validationCheck = new EditNotesheetCommandValidator().Validate(Notesheet);
            validationCheck.AddToModelState(ModelState, nameof(Notesheet));

            if (notesheet == null)
            {
                return NotFound();
            }

            InitSelectListItems(notesheet);

            if (!ModelState.IsValid)
            {
                return Page();
            }


            List<string> errors = await _mediator.Send(Notesheet);

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            // check if we have any errors and redirect if successful
            if (errors.Count == 0)
            {
                _logger.LogInformation("Contract Proposal edit operation successful");
                return RedirectToPage($"./{nameof(Index)}").WithSuccess("Contract Proposal Editing done");
            }

            return Page();
        }

        public void InitSelectListItems(Notesheet notesheet)
        {
            // populate the proposal for approval objects
            ProposalForApprovals = notesheet.ProposalForApprovals;

            TypeOptions = new SelectList(TypeConstants.GetTypesOptions());
            ModeOfTender = new SelectList(ModeOfTenderConstants.GetModeOfTenderOptions());
            TypeOfBiddingOptions = new SelectList(TypeOfBiddingConstants.GetTypeOfBiddingOptions());
            BudgetProvisionOptions = new SelectList(BudgetProvisionConstants.GetBudgetProvisionOptions());
            ProposalForApprovalOptions = new SelectList(ProposalForApprovalConstants.GetProposalForApprovalOptions());
            IndentingDeptOptions = new SelectList(IndentingDeptConstants.GetIndentingDeptOptions());
        }
    }
}
