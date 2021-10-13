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

namespace Application.Notesheets.Queries.GetNotesheets
{
    public class GetNotesheetsQuery : IRequest<List<Notesheet>>
    {
        public class GetNotesheetsQueryHandler : IRequestHandler<GetNotesheetsQuery, List<Notesheet>>
        {
            private readonly IAppDbContext _context;

            public GetNotesheetsQueryHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<List<Notesheet>> Handle(GetNotesheetsQuery request, CancellationToken cancellationToken)
            {
                List<Notesheet> res = await _context.Notesheets.ToListAsync();
                return res;
            }
        }
    }
}
