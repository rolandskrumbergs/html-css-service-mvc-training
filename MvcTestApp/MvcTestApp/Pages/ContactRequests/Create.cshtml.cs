using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcTestApp.Database;

namespace MvcTestApp.Pages.ContactRequests
{
    public class CreateModel : PageModel
    {
        private readonly MvcTestApp.Database.MvcTestAppDbContext _context;

        public CreateModel(MvcTestApp.Database.MvcTestAppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactRequest ContactRequest { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ContactRequests.Add(ContactRequest);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
