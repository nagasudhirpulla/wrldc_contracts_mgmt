using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notesheets.Commands.CreateNotesheet
{
   public  class CreateNotesheetCommand :IRequest<List<string>>
    {
        public string ReferenceNo { get; set; }

        public string PackageName { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public string ScopeOfWork { get; set; }

        public string Technical_Specification { get; set; }
        public float EstimatedCost { get; set; }

        public string BillOfQuantity { get; set; }

        public string Guarantee_Warranty { get; set; }

        public string Payment_Terms_CPG { get; set; }

        public string ModeOfTerm { get; set; }

        public string TypeOfBidding { get; set; }

        public string ListOfParties { get; set; }

        public string GeMNonAvailabilityCertificate { get; set; }

        public string WorkCompletionSchedule { get; set; }

        public string SpecialConditionsOfContract { get; set; }

        public string BudgetProvision { get; set; }

        //public string ProposalForApproval { get; set; }
        public string[] ProposalOptions { get; set; }
        public string ApprovingAuthority { get; set; }
    }
}
