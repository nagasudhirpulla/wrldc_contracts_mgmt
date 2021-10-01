using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Notesheets.Commands.EditNotesheet
{
   public class EditNotesheetCommandHandler : IRequestHandler<EditNotesheetCommand, List<string>>
    {
        private readonly ILogger<EditNotesheetCommandHandler> _logger;
        private readonly IAppDbContext _context;

        public EditNotesheetCommandHandler(ILogger<EditNotesheetCommandHandler> logger, IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<string>> Handle(EditNotesheetCommand request, CancellationToken cancellationToken)
        {
            
            // fetch the order for editing
            var notesheet = await _context.Notesheets.Where(ns => ns.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            if (notesheet == null)
            {
                string errorMsg = $"Notesheet Id {request.Id} not present for editing";
                return new List<string>() { errorMsg };
            }
            if (notesheet.ReferenceNo != request.ReferenceNo)
            {
                notesheet.ReferenceNo = request.ReferenceNo;
            }
            if (notesheet.PackageName != request.PackageName)
            {
                notesheet.PackageName = request.PackageName;
            }
            if (notesheet.Type != request.Type)
            {
                notesheet.Type = request.Type;
            }
            if (notesheet.Description != request.Description)
            {
                notesheet.Description = request.Description;
            }
            if (notesheet.ScopeOfWork != request.ScopeOfWork)
            {
                notesheet.ScopeOfWork = request.ScopeOfWork;
            }
            if (notesheet.Technical_Specification != request.Technical_Specification)
            {
                notesheet.Technical_Specification = request.Technical_Specification;
            }
            if (notesheet.EstimatedCost != request.EstimatedCost)
            {
                notesheet.EstimatedCost = request.EstimatedCost;
            }
            if (notesheet.BudgetOfferReference != request.BudgetOfferReference)
            {
                notesheet.BudgetOfferReference = request.BudgetOfferReference;
            }
            if (notesheet.BudgetOfferDate != request.BudgetOfferDate)
            {
                notesheet.BudgetOfferDate = request.BudgetOfferDate;
            }
            if (notesheet.BudgetOfferReference != request.BudgetOfferReference)
            {
                notesheet.EstimatedCost = request.EstimatedCost;
            }
            if (notesheet.EstimatedCost != request.EstimatedCost)
            {
                notesheet.EstimatedCost = request.EstimatedCost;
            }
            if (notesheet.BillOfQuantity != request.BillOfQuantity)
            {
                notesheet.BillOfQuantity = request.BillOfQuantity;
            }
            if (notesheet.Payment_Terms_CPG != request.Payment_Terms_CPG)
            {
                notesheet.Payment_Terms_CPG = request.Payment_Terms_CPG;
            }
            if (notesheet.ModeOfTerm != request.ModeOfTerm)
            {
                notesheet.ModeOfTerm = request.ModeOfTerm;
            }
            if (notesheet.TypeOfBidding != request.TypeOfBidding)
            {
                notesheet.TypeOfBidding = request.TypeOfBidding;
            }
            if (notesheet.ListOfParties != request.ListOfParties)
            {
                notesheet.ListOfParties = request.ListOfParties;
            }
            if (notesheet.GeMNonAvailabilityCertificate != request.GeMNonAvailabilityCertificate)
            {
                notesheet.GeMNonAvailabilityCertificate = request.GeMNonAvailabilityCertificate;
            }
            if (notesheet.WorkCompletionSchedule != request.WorkCompletionSchedule)
            {
                notesheet.WorkCompletionSchedule = request.WorkCompletionSchedule;
            }
            if (notesheet.SpecialConditionsOfContract != request.SpecialConditionsOfContract)
            {
                notesheet.SpecialConditionsOfContract = request.SpecialConditionsOfContract;
            }
            if (notesheet.BudgetProvision != request.BudgetProvision)
            {
                notesheet.BudgetProvision = request.BudgetProvision;
            }
            if (notesheet.DopClause != request.DopClause)
            {
                notesheet.DopClause = request.DopClause;
            }
            if (notesheet.ApprovingAuthority != request.ApprovingAuthority)
            {
                notesheet.ApprovingAuthority = request.ApprovingAuthority;
            }
            
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Notesheets.Any(e => e.Id == request.Id))
                {
                    return new List<string>() { $"Order Id {request.Id} not present for editing" };
                }
                else
                {
                    throw;
                }
            }

            return new List<string>();

        }
    }
}
