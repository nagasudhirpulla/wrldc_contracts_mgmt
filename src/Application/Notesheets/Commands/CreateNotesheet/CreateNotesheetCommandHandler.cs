using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Notesheets.Commands.CreateNotesheet
{
    class CreateNotesheetCommandHandler : IRequestHandler<CreateNotesheetCommand, List<string>>
    {
        private readonly IAppDbContext _context;

        public CreateNotesheetCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(CreateNotesheetCommand request, CancellationToken cancellationToken)
        {
            Notesheet notesheet = new()
            {
                IndentingDept = request.IndentingDept,
                ReferenceNo = request.ReferenceNo,
                PackageName = request.PackageName,
                Type = request.Type,
                Description = request.Description,
                ScopeOfWork = request.ScopeOfWork,
                Technical_Specification = request.Technical_Specification,
                EstimatedCost = request.EstimatedCost,
                BillOfQuantity = request.BillOfQuantity,
                Guarantee_Warranty = request.Guarantee_Warranty,
                Payment_Terms_CPG = request.Payment_Terms_CPG,
                ModeOfTerm = request.ModeOfTerm,
                ReasonsForModeOfTender = request.ReasonsForModeOfTender,
                ProprietaryArticleCertificate = request.ProprietaryArticleCertificate,
                TypeOfBidding = request.TypeOfBidding,
                ListOfParties = request.ListOfParties,
                GeMNonAvailabilityCertificate = request.GeMNonAvailabilityCertificate,
                WorkCompletionSchedule = request.WorkCompletionSchedule,
                SpecialConditionsOfContract = request.SpecialConditionsOfContract,
                OtherPointsRelevantWithCase = request.OtherPointsRelevantWithCase,
                BudgetProvision = request.BudgetProvision,
                BPSerialNo = request.BPSerialNo,
                BPUnderHead = request.BPUnderHead,
                ApprovingAuthority = request.ApprovingAuthority,
                DopClause = request.DopClause,
                DopSection= request.DopSection,
                BudgetOfferReference = request.BudgetOfferReference,
                BudgetOfferAddress = request.BudgetOfferAddress,
                BudgetOfferDate = request.BudgetOfferDate,
                BudgetOfferValidity = request.BudgetOfferValidity
            };

            

            _context.Notesheets.Add(notesheet);
            _ = await _context.SaveChangesAsync(cancellationToken);

            // create child entities for each proposal options
            foreach (string pOptTxt in request.ProposalOptions)
            {
                string proposalOptnTxt = pOptTxt;
                if (pOptTxt.ToLower() == "others")
                {
                    proposalOptnTxt = request.ProposalForApprovalOthersOption; // get this from request
                }
                ProposalForApproval prpslForApproval = new()
                {
                    NotesheetId = notesheet.Id,
                    ProposalOption = proposalOptnTxt
                };
                _context.ProposalForApprovals.Add(prpslForApproval);
                _ = await _context.SaveChangesAsync(cancellationToken);
            }

            return new List<string>();
        }
    }
}
