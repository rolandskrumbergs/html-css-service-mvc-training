using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTestApp.Database
{
    public class MvcTestAppDbContext : DbContext
    {
        public MvcTestAppDbContext(DbContextOptions<MvcTestAppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactRequest> ContactRequests { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
