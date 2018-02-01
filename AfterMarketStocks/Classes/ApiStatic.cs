using AfterMarketStocks.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfterMarketStocks.Classes
{
    public static class ApiStatic
    {

        // GET: StockApi
        public static string GetCurrentPrice(string symbol)
        {
            // get current time
            var split = symbol.Split(' ');
            var joinSymbol = String.Join("+", split);

            AlphaStock alphaStock = new AlphaStock();

            var client = new RestClient("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol="+joinSymbol+"&interval=1min&apikey=VJENW28SN49JRMYV");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Postman-Token", "2623fc44-fda5-6ce1-f656-ea90d2e4d0f9");
            request.AddHeader("Cache-Control", "no-cache");
            string stockPrice = "not found";
            try
            {
                IRestResponse response = client.Execute(request);

                AlphaStock responseData = AlphaStock.FromJson(response.Content);
                stockPrice = responseData.TimeSeries1Min["2018-02-01 14:50:00"].The2High.ToString();
            }
            catch (Exception)
            {

                
            }
            

            return stockPrice;
        }
    }
}