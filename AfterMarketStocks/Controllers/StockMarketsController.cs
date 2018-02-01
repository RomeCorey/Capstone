using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AfterMarketStocks.Models;
using Microsoft.AspNet.Identity;

namespace AfterMarketStocks.Controllers
{
    [Authorize]
    public class StockMarketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockMarkets
        public ActionResult Index()
        {
            return View(db.StockMarkets.ToList());
        }

        // GET: StockMarkets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMarket stockMarket = db.StockMarkets.Find(id);
            if (stockMarket == null)
            {
                return HttpNotFound();
            }
            return View(stockMarket);
        }

        // GET: StockMarkets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockMarkets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stockMarketId")] StockMarket stockMarket)
        {
            if (ModelState.IsValid)
            {
                db.StockMarkets.Add(stockMarket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockMarket);
        }

        // GET: StockMarkets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMarket stockMarket = db.StockMarkets.Find(id);
            if (stockMarket == null)
            {
                return HttpNotFound();
            }
            return View(stockMarket);
        }

        // POST: StockMarkets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stockMarketId")] StockMarket stockMarket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockMarket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockMarket);
        }

        // GET: StockMarkets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockMarket stockMarket = db.StockMarkets.Find(id);
            if (stockMarket == null)
            {
                return HttpNotFound();
            }
            return View(stockMarket);
        }

        // POST: StockMarkets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockMarket stockMarket = db.StockMarkets.Find(id);
            db.StockMarkets.Remove(stockMarket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public  ActionResult Watchlist()
        {
            
            return View();
        }
    }
}
