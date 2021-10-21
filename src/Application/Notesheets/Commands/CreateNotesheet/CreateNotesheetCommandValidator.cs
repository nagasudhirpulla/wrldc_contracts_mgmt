using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notesheets.Commands.CreateNotesheet
{
    public class CreateNotesheetCommandValidator : AbstractValidator<CreateNotesheetCommand>
    {
        public CreateNotesheetCommandValidator()
        {
            RuleFor(x => x.ReferenceNo).NotEmpty();
            RuleFor(x => x.PackageName).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ScopeOfWork).NotEmpty();
            RuleFor(x => x.EstimatedCost).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BillOfQuantity).NotEmpty();
            RuleFor(x => x.Guarantee_Warranty).NotEmpty();
            RuleFor(x => x.Payment_Terms_CPG).NotEmpty();
            RuleFor(x => x.ModeOfTerm).NotEmpty();
            //RuleFor(x => x.TypeOfBidding).NotEmpty();
            RuleFor(x => x.BudgetProvision).NotEmpty();
            //RuleFor(x => x.ProposalForApproval).NotEmpty();
            RuleFor(x => x.ApprovingAuthority).NotEmpty();
            RuleFor(x => x.DopClause).NotEmpty();
            RuleFor(x => x.IndentingDept).NotEmpty();
            RuleFor(x => x.BPSerialNo).NotEmpty();
            RuleFor(x => x.BPUnderHead).NotEmpty();
            RuleFor(x => x.DopSection).NotEmpty();
            RuleFor(x => x.CPG).NotEmpty();

        }
    }
}
