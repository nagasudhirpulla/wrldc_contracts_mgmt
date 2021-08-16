using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notesheets
{
    public class BudgetProvisionConstants
    {
        public const string CAPEX = "CAPEX";
        public const string REPEX = "REPEX";
        public const string OPEX = "OPEX";
        public const string CSR = "CSR";
        public const string O_M = "O&M";


        public static List<string> GetBudgetProvisionOptions()
        {
            return typeof(BudgetProvisionConstants).GetFields().Select(x => x.GetValue(null).ToString()).ToList();
        }
    }
}
