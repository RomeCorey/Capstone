using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfterMarketStocks.Models
{
    public class UserstockJunction
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public BuySell Stock { get; set; }
    }
}