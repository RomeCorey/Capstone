using AfterMarketStocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AfterMarketStocks.Controllers
{
    public class StripeController : Controller
    {
        

            // GET: StripeAPI
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            //var customers = new StripeCustomerService();
            //var charges = new StripeChargeService();

            //var customer = customers.Create(new StripeCustomerCreateOptions
            //{
            //    Email = stripeEmail,
            //    SourceToken = stripeToken
            //});

            //var charge = charges.Create(new StripeChargeCreateOptions
            //{
            //    Amount = 500,
            //    Description = "Sample Charge",
            //    Currency = "usd",
            //    CustomerId = customer.Id
            //});

            string apiKey = "sk_test_au9OvT8hhccPg1LdlKZ3nYX6";
            var stripeClient = new Stripe.StripeClient(apiKey);

            dynamic response = stripeClient.CreateChargeWithToken(2500, stripeToken, "GBP", stripeEmail);

            if (response.IsError == false && response.Paid)
            {
                // success
            }

            return View();

        }
    }
}