using Application.Common.Interfaces;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Notesheets.Queries.GetNotesheetById
{
    public class GetNotesheetByIdQuery:IRequest<Notesheet>
    {
        public int Id { get; set; }
    }

    public class GetNotesheetByIdQueryHandler : IRequestHandler<GetNotesheetByIdQuery, Notesheet>
    {
        private readonly IAppDbContext _context;

        public GetNotesheetByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        async Task<Notesheet> IRequestHandler<GetNotesheetByIdQuery, Notesheet>.Handle(GetNotesheetByIdQuery request, CancellationToken cancellationToken)
        {
            Notesheet res = await _context.Notesheets.Where(co => co.Id == request.Id)
                                            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
            return res;
        }
    }
}
