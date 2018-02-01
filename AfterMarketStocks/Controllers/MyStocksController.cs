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
    public class MyStocksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyStocks
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();
            List<UserstockJunction> stockList = (from x in db.UserStocks.Include("Stock") where x.User.Id == userid select x).ToList();
            foreach(UserstockJunction item in stockList)
            {
                item.Stock.currentPrice= Classes.ApiStatic.GetCurrentPrice(item.Stock.symbol);
            }

            return View(stockList);
        }

        // GET: MyStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyStocks myStocks = db.MyStocks.Find(id);
            if (myStocks == null)
            {
                return HttpNotFound();
            }
            return View(myStocks);
        }

        // GET: MyStocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "myStockId,stock,currentPrice,symbol")] MyStocks myStocks)
        {
            if (ModelState.IsValid)
            {
                db.MyStocks.Add(myStocks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myStocks);
        }

        // GET: MyStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyStocks myStocks = db.MyStocks.Find(id);
            if (myStocks == null)
            {
                return HttpNotFound();
            }
            return View(myStocks);
        }

        // POST: MyStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "myStockId,stock,currentPrice")] MyStocks myStocks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myStocks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myStocks);
        }

        // GET: MyStocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserstockJunction myStocks = db.UserStocks.Find(id);
            if (myStocks == null)
            {
                return HttpNotFound();
            }
            return View(myStocks);
        }

        // POST: MyStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserstockJunction myStocks = (from x in db.UserStocks.Include("Stock") where x.Id == id select x).FirstOrDefault();
            db.UserStocks.Remove(myStocks);
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
