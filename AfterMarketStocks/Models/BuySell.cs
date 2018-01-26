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
        [Display(Name = "Stock")]
        public IEnumerable userStocks { get; set; }
        [Display(Name = "Stock")]
        public string userStock { get; set; }
        [Display(Name = "Current Price")]
        public float currentPrice { get; set; }
        [Display(Name = "Buy")]
        public string buy { get; set; }
        [Display(Name = "Sell")]
        public string sell { get; set; }
    }
}