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
    public class BuySellsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BuySells
        public ActionResult Index()
        {
            List<BuySell> stockList = db.BuySells.ToList();
            foreach (BuySell item in stockList)
            {
                item.currentPrice = Classes.ApiStatic.GetCurrentPrice(item.symbol);
            }

            return View(stockList);
        }

        public ActionResult AddStockAndRedirectToIndex(int id)
        {
            var userid = User.Identity.GetUserId();
            UserstockJunction userstock = new UserstockJunction();
            userstock.Stock = (from x in db.BuySells where x.buySellId == id select x).FirstOrDefault();
            userstock.User = (from x in db.Users where x.Id == userid select x).FirstOrDefault();
            db.UserStocks.Add(userstock);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: BuySells/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuySell buySell = db.BuySells.Find(id);
            if (buySell == null)
            {
                return HttpNotFound();
            }
            return View(buySell);
        }

        // GET: BuySells/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuySells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "buySellId,stock,currentPrice,symbol")] BuySell buySell)
        {
            if (ModelState.IsValid)
            {
                db.BuySells.Add(buySell);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buySell);
        }

        // GET: BuySells/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuySell buySell = db.BuySells.Find(id);
            if (buySell == null)
            {
                return HttpNotFound();
            }
            return View(buySell);
        }

        // POST: BuySells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "buySellId,userStock,currentPrice,buy,sell")] BuySell buySell)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buySell).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buySell);
        }

        // GET: BuySells/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuySell buySell = db.BuySells.Find(id);
            if (buySell == null)
            {
                return HttpNotFound();
            }
            return View(buySell);
        }

        // POST: BuySells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuySell buySell = db.BuySells.Find(id);
            db.BuySells.Remove(buySell);
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
    }
}
