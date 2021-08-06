using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;
using Microsoft.Extensions.Logging;
using MediatR;
using Application.Notesheets.Commands.EditNotesheet;
using Application.Notesheets.Queries.GetNotesheetById;
using AutoMapper;
using WebApp.Extensions;

namespace WebApp.Pages.Notesheets
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EditModel(ILogger<EditModel> logger,
                         IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [BindProperty]
        public EditNotesheetCommand Notesheet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notesheet ns = await _mediator.Send(new GetNotesheetByIdQuery() { Id = id.Value });

            if (ns == null)
            {
                return NotFound();
            }
            Notesheet = _mapper.Map<EditNotesheetCommand>(ns);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<string> errors = await _mediator.Send(Notesheet);

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            // check if we have any errors and redirect if successful
            if (errors.Count == 0)
            {
                _logger.LogInformation("User edit operation successful");
                return RedirectToPage($"./{nameof(Index)}").WithSuccess("Notesheet Editing done");
            }

            return Page();
        }
    }
}
