using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcTestApp.Database;

namespace MvcTestApp.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly MvcTestApp.Database.MvcTestAppDbContext _context;

        public IndexModel(MvcTestApp.Database.MvcTestAppDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders.ToListAsync();
        }
    }
}
