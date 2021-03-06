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

        public string IndentingDept { get; set; }  //new field
        public string ReferenceNo { get; set; }

        public string PackageName { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public string ScopeOfWork { get; set; }

        public string Technical_Specification { get; set; }

        public float EstimatedCost { get; set; }

        public string BudgetOfferReference { get; set; }

        public DateTime BudgetOfferDate { get; set; }

        public string BudgetOfferValidity { get; set; }

        public string BudgetOfferAddress { get; set; }

        public string BillOfQuantity { get; set; }

        public string Guarantee_Warranty { get; set; }

        public string Payment_Terms_CPG { get; set; }

        public string CPG { get; set; }

        public string ModeOfTerm { get; set; }
        public string ReasonsForModeOfTender { get; set; }  //new field

        public string ProprietaryArticleCertificate { get; set; }  //new field

        public string TypeOfBidding { get; set; }

        public string ListOfParties { get; set; }

        public string GeMNonAvailabilityCertificate { get; set; }

        public string WorkCompletionSchedule { get; set; }

        public string SpecialConditionsOfContract { get; set; }

        public string OtherPointsRelevantWithCase { get; set; }  //new field


        public string BudgetProvision { get; set; }

        public string BPSerialNo { get; set; }    //new field
        public string BPUnderHead { get; set; }   //new field

        public string DopClause { get; set; }
        public string DopSection { get; set; }   //new field

        public ICollection<ProposalForApproval> ProposalForApprovals { get; private set; }

        public string ApprovingAuthority { get; set; }
    }
}
