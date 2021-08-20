using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notesheets
{
    public class ProposalForApprovalConstants
    {
        public const string TAAFCE = "Technical & Administrative approval for Cost Estimate";
        public const string COC = "Constitution of Committee";
        public const string MOT = "Mode of tender";
        
        public static List<string> GetProposalForApprovalOptions()
        {
            return typeof(ProposalForApprovalConstants).GetFields().Select(x => x.GetValue(null).ToString()).ToList();
        }
    }
}
