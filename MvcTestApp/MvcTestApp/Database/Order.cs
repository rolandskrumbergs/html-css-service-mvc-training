using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTestApp.Database
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int FirstBookAmount { get; set; }
        public int SecondBookAmount { get; set; }
        public int ThirdBookAmount { get; set; }
        public bool Priority { get; set; }
        public string Status { get; set; }
    }
}
