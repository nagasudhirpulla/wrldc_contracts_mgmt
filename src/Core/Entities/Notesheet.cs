using Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Notesheet : AuditableEntity
    {
        public Notesheet()
        {
            ProposalForApprovals = new HashSet<ProposalForApproval>();
        }
        [Required]
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

        public ICollection<ProposalForApproval> ProposalForApprovals { get; private set; }
        public string ApprovingAuthority { get; set; }








    }
}
