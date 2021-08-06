using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Notesheets.Commands.CreateNotesheet
{
    class CreateNotesheetCommandHandler : IRequestHandler<CreateNotesheetCommand, List<string>>
    {
        private readonly IAppDbContext _context;

        public CreateNotesheetCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> Handle(CreateNotesheetCommand request, CancellationToken cancellationToken)
        {
            Notesheet notesheet = new()
            {
                ReferenceNo = request.ReferenceNo,
                PackageName = request.PackageName,
                Type = request.Type,
                Description = request.Description,
                ScopeOfWork = request.ScopeOfWork,
                Technical_Specification = request.Technical_Specification,
                
            };

            _context.Notesheets.Add(notesheet);
            _ = await _context.SaveChangesAsync(cancellationToken);

            return new List<string>();
        }
    }
}
