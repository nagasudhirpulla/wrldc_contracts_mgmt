using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notesheets
{
    public static class TypeConstants
    {
        public const string Supply = "Supply";
        public const string SITC = "Supply, Installation, Testing & Commissioning";
        public const string Works = "Works";
        public const string Service = "Service";
        public const string AMC = "AMC";
        public static List<string> GetTypesOptions()
        {
            return typeof(TypeConstants).GetFields().Select(x => x.GetValue(null).ToString()).ToList();
        }
    }
}
