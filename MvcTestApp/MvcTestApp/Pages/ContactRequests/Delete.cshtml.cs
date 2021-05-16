using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcTestApp.Database;

namespace MvcTestApp.Pages.ContactRequests
{
    public class DeleteModel : PageModel
    {
        private readonly MvcTestApp.Database.MvcTestAppDbContext _context;

        public DeleteModel(MvcTestApp.Database.MvcTestAppDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactRequest = await _context.ContactRequests.FindAsync(id);

            if (ContactRequest != null)
            {
                _context.ContactRequests.Remove(ContactRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
