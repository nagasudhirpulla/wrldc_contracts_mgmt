using Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProposalForApproval : BaseEntity
    {
        public Notesheet Notesheet { get; set; }
        public int NotesheetId { get; set; }
        public string ProposalOption { get; set; }
    }
}
