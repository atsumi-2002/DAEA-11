using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstDemo.Models;

namespace CodeFirstDemo.Controllers
{
    public class InvoiceDetailsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: InvoiceDetails
        public ActionResult Index()
        {
            var invoiceDetails = db.InvoiceDetails.Include(i => i.Customer).Include(i => i.Invoice).Include(i => i.Seller);
            return View(invoiceDetails.ToList());
        }

        // GET: InvoiceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            if (invoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name");
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceNumber");
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "Name");
            return View();
        }

        // POST: InvoiceDetails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceDetailID,Date,CustomerID,SellerID,InvoiceID")] InvoiceDetail invoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceDetails.Add(invoiceDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", invoiceDetail.CustomerID);
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceNumber", invoiceDetail.InvoiceID);
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "Name", invoiceDetail.SellerID);
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            if (invoiceDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", invoiceDetail.CustomerID);
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceNumber", invoiceDetail.InvoiceID);
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "Name", invoiceDetail.SellerID);
            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceDetailID,Date,CustomerID,SellerID,InvoiceID")] InvoiceDetail invoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "Name", invoiceDetail.CustomerID);
            ViewBag.InvoiceID = new SelectList(db.Invoices, "InvoiceID", "InvoiceNumber", invoiceDetail.InvoiceID);
            ViewBag.SellerID = new SelectList(db.Sellers, "SellerID", "Name", invoiceDetail.SellerID);
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            if (invoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            db.InvoiceDetails.Remove(invoiceDetail);
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
