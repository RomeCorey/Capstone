using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AfterMarketStocks.Models
{
    public class BuySell
    {
        [Key]
        public int buySellId { get; set; }
        public IEnumerable userStocks { get; set; }
    }
}