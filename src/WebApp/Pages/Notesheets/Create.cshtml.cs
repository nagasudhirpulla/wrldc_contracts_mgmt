using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Core.Entities;
using Infra.Persistence;
using Application.Notesheets.Commands.CreateNotesheet;
using MediatR;
using Application.Notesheets;

namespace WebApp.Pages.Notesheets
{
    public class CreateModel : PageModel
    {
        private readonly IMediator _mediator;

        public CreateModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public SelectList TypeOptions { get; set; }
        public async Task OnGetAsync()
        {
            await InitSelectListItems();
            //return Page();
        }

        [BindProperty]
        public CreateNotesheetCommand Notesheet { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await InitSelectListItems();
            // create new order
            List<string> errors = await _mediator.Send(Notesheet);

            if (errors.Count == 0)
            {
                
                return RedirectToPage("./Index");
            }

            foreach (var err in errors)
            {
                ModelState.AddModelError(string.Empty, err);
            }
            
                return Page();
            

            
        }
        public async Task InitSelectListItems()
        {
            
            TypeOptions = new SelectList(TypeConstants.GetTypesOptions());
        }
    }
}
