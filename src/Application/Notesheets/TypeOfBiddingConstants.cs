using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notesheets
{
   public  class TypeOfBiddingConstants
    {
        public const string SSTE = "Single Stage Two Envelopes";
        public const string SSSE = "Single Stage Single Envelopes";
        public const string TS = "Two Stage";
        public const string QCBS = "QCBS";
        public const string ENLISTMENT = "Enlistment";


        public static List<string> GetTypeOfBiddingOptions()
        {
            return typeof(TypeOfBiddingConstants).GetFields().Select(x => x.GetValue(null).ToString()).ToList();
        }
    }
}
