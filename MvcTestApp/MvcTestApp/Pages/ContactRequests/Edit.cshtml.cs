using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcTestApp.Database;

namespace MvcTestApp.Pages.ContactRequests
{
    public class EditModel : PageModel
    {
        private readonly MvcTestApp.Database.MvcTestAppDbContext _context;

        public EditModel(MvcTestApp.Database.MvcTestAppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactRequest ContactRequest { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactRequest = await _context.ContactRequests.FirstOrDefaultAsync(m => m.Id == id);

            if (ContactRequest == null)
            {
                return NotFound();
            }
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

            _context.Attach(ContactRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactRequestExists(ContactRequest.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactRequestExists(int id)
        {
            return _context.ContactRequests.Any(e => e.Id == id);
        }
    }
}
