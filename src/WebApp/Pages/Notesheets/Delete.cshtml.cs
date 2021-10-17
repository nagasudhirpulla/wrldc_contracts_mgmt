using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infra.Persistence;
using MediatR;
using Application.Notesheets.Commands.DeleteNotesheet;
using WebApp.Extensions;
using Microsoft.Extensions.Logging;
using Application.Notesheets.Queries.GetNotesheetById;

namespace WebApp.Pages.Notesheets
{
    public class DeleteModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EditModel> _logger;

        public DeleteModel(IMediator mediator, ILogger<EditModel> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [BindProperty]
        public Notesheet Notesheet { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Notesheet = await _mediator.Send(new GetNotesheetByIdQuery() { Id = id.Value });

            if (Notesheet == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<string> errors = await _mediator.Send(new DeleteNotesheetCommand() { Id = id.Value });

            // check if we have any errors and redirect if successful
            if (errors.Count == 0)
            {
                _logger.LogInformation("Contract Proposal delete operation successful");
                return RedirectToPage($"./{nameof(Index)}").WithSuccess("Contract Proposal Deletion done");
            }

            return RedirectToPage($"./{nameof(Index)}").WithDanger("Unable to delete Contract Proposal...");
        }
    }
}
