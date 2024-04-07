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
    public class DeliveryAddressesController : Controller
    {
        private TextilContext db = new TextilContext();

        // GET: DeliveryAddresses
        public ActionResult Index()
        {
            var deliveryAddresses = db.DeliveryAddresses.Include(d => d.Customer);
            return View(deliveryAddresses.ToList());
        }

        // GET: DeliveryAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryAddress deliveryAddress = db.DeliveryAddresses.Find(id);
            if (deliveryAddress == null)
            {
                return HttpNotFound();
            }
            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            return View();
        }

        // POST: DeliveryAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,Phone,Email,ContactPerson,ContactPersonPhone,ContactPersonEmail,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,CustomerId")] DeliveryAddress deliveryAddress)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryAddresses.Add(deliveryAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", deliveryAddress.CustomerId);
            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryAddress deliveryAddress = db.DeliveryAddresses.Find(id);
            if (deliveryAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", deliveryAddress.CustomerId);
            return View(deliveryAddress);
        }

        // POST: DeliveryAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,Phone,Email,ContactPerson,ContactPersonPhone,ContactPersonEmail,Notes,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,CustomerId")] DeliveryAddress deliveryAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", deliveryAddress.CustomerId);
            return View(deliveryAddress);
        }

        // GET: DeliveryAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryAddress deliveryAddress = db.DeliveryAddresses.Find(id);
            if (deliveryAddress == null)
            {
                return HttpNotFound();
            }
            return View(deliveryAddress);
        }

        // POST: DeliveryAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryAddress deliveryAddress = db.DeliveryAddresses.Find(id);
            db.DeliveryAddresses.Remove(deliveryAddress);
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
