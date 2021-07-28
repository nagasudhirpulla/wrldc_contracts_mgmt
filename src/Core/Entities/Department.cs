using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;

namespace Core.Entities
{
    public class Department: AuditableEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Acronym { get; set; }
    }
}
