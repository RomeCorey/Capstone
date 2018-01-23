using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AfterMarketStocks.Models
{
    public class StockMarket
    {
        [Key]
        public int stockMarketId { get; set; }
    }
}