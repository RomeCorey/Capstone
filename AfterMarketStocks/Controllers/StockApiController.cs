using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AfterMarketStocks.Controllers
{
    public class StockApiController : Controller
    {
        // GET: StockApi
        public ActionResult Index()
        {

            var client = new RestClient("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=MSFT&interval=1min&apikey=VJENW28SN49JRMYV");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "2623fc44-fda5-6ce1-f656-ea90d2e4d0f9");
            request.AddHeader("Cache-Control", "no-cache");
            IRestResponse response = client.Execute(request);



            return View();
        }
    }
}