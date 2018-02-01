using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AfterMarketStocks.Models
{
    public class MyStocks
    {
        [Key]
        public int myStockId { get; set; }
        
        [Display(Name = "Stock")]
        public IEnumerable userStocks { get; set; }
        [Display(Name = "Stock")]
        public string stock { get; set; }
        [Display(Name = "Symbol")]
        public string symbol { get; set; }
        [Display(Name = "Current Price")]
        public string currentPrice { get; set; }
        
    }
}