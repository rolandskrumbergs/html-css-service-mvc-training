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
    public class IndexModel : PageModel
    {
        private readonly MvcTestApp.Database.MvcTestAppDbContext _context;

        public IndexModel(MvcTestApp.Database.MvcTestAppDbContext context)
        {
            _context = context;
        }

        public IList<ContactRequest> ContactRequest { get;set; }

        public async Task OnGetAsync()
        {
            ContactRequest = await _context.ContactRequests.ToListAsync();
        }
    }
}
