using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notesheets
{
    public class IndentingDeptConstants
    {
        public const string IT = "IT";
        public const string RE_R = "RE&R";
        public const string TS = "TS";
        public const string HR = "HR";
        public const string Logistic = "Logistic";
        public const string Finance = "Finance";

        public static List<string> GetIndentingDeptOptions()
        {
            return typeof(IndentingDeptConstants).GetFields().Select(x => x.GetValue(null).ToString()).ToList();
        }
    }
}
