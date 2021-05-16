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
    public class DetailsModel : PageModel
    {
        private readonly MvcTestApp.Database.MvcTestAppDbContext _context;

        public DetailsModel(MvcTestApp.Database.MvcTestAppDbContext context)
        {
            _context = context;
        }

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
    }
}
