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
        public string userName { get; set; }
        public IEnumerable userStocks { get; set; }
    }
}