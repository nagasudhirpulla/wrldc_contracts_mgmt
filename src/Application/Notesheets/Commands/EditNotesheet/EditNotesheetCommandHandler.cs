using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Notesheets.Commands.EditNotesheet
{
   public class EditNotesheetCommandHandler : IRequestHandler<EditNotesheetCommand, List<string>>
    {
        private readonly ILogger<EditNotesheetCommandHandler> _logger;
        private readonly IAppDbContext _context;

        public EditNotesheetCommandHandler(ILogger<EditNotesheetCommandHandler> logger, IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<string>> Handle(EditNotesheetCommand request, CancellationToken cancellationToken)
        {
            
            // fetch the order for editing
            var notesheet = await _context.Notesheets.Where(ns => ns.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

            if (notesheet == null)
            {
                string errorMsg = $"Notesheet Id {request.Id} not present for editing";
                return new List<string>() { errorMsg };
            }
            if (notesheet.ReferenceNo != request.ReferenceNo)
            {
                notesheet.ReferenceNo = request.ReferenceNo;
            }
            if (notesheet.PackageName != request.PackageName)
            {
                notesheet.PackageName = request.PackageName;
            }
            if (notesheet.Type != request.Type)
            {
                notesheet.Type = request.Type;
            }
            if (notesheet.Description != request.Description)
            {
                notesheet.Description = request.Description;
            }
            if (notesheet.ScopeOfWork != request.ScopeOfWork)
            {
                notesheet.ScopeOfWork = request.ScopeOfWork;
            }
            if (notesheet.Technical_Specification != request.Technical_Specification)
            {
                notesheet.Technical_Specification = request.Technical_Specification;
            }
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Notesheets.Any(e => e.Id == request.Id))
                {
                    return new List<string>() { $"Order Id {request.Id} not present for editing" };
                }
                else
                {
                    throw;
                }
            }

            return new List<string>();

        }
    }
}
