using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;

namespace WebApp.Pages.Notesheets
{
    public class IndexModel : PageModel
    {
        private readonly Infra.Persistence.AppDbContext _context;

        public IndexModel(Infra.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public IList<Notesheet> Notesheet { get;set; }

        public async Task OnGetAsync()
        {
            Notesheet = await _context.Notesheets.ToListAsync();
        }
    }
}
