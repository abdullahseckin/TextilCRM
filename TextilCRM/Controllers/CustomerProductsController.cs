using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TextilCRM.DAL;
using TextilCRM.Models;

namespace TextilCRM.Controllers
{
    public class CustomerProductsController : Controller
    {
        private TextilContext db = new TextilContext();

        // GET: CustomerProducts
        public ActionResult Index()
        {
            var customerProducts = db.CustomerProducts.Include(c => c.Customer).Include(c => c.Product);
            return View(customerProducts.ToList());
        }

        // GET: CustomerProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProduct customerProduct = db.CustomerProducts.Find(id);
            if (customerProduct == null)
            {
                return HttpNotFound();
            }
            return View(customerProduct);
        }

        // GET: CustomerProducts/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: CustomerProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,ProductId,Name,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] CustomerProduct customerProduct)
        {
            if (ModelState.IsValid)
            {
                db.CustomerProducts.Add(customerProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", customerProduct.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", customerProduct.ProductId);
            return View(customerProduct);
        }

        // GET: CustomerProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProduct customerProduct = db.CustomerProducts.Find(id);
            if (customerProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", customerProduct.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", customerProduct.ProductId);
            return View(customerProduct);
        }

        // POST: CustomerProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,ProductId,Name,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate")] CustomerProduct customerProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", customerProduct.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", customerProduct.ProductId);
            return View(customerProduct);
        }

        // GET: CustomerProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProduct customerProduct = db.CustomerProducts.Find(id);
            if (customerProduct == null)
            {
                return HttpNotFound();
            }
            return View(customerProduct);
        }

        // POST: CustomerProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerProduct customerProduct = db.CustomerProducts.Find(id);
            db.CustomerProducts.Remove(customerProduct);
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
