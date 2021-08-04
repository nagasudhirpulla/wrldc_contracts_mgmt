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
        [Required]
        public string ReferenceNo { get; set; }

        public string PackageName { get; set; }
        public string Type { get; set; }

        public string Description { get; set; }

        public string ScopeOfWork { get; set; }

        public string Technical_Specification { get; set; }





    }
}
