using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notesheets.Commands.DeleteNotesheet
{
    public class DeleteNotesheetCommand:IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
