﻿using System;
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
        [Display(Name = "Symbol")]
        public string symbol { get; set; }
        [Display(Name = "Current Price")]
        public string currentPrice { get; set; }
        
    }
}