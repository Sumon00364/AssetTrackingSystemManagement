using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;

namespace AssetTrackingSystem.MVC.Controllers.AssetModels.AssetEntries
{
    public class FinancesController : Controller
    {
        private AssetDbContext db = new AssetDbContext();

        // GET: Finances
        public ActionResult Index()
        {
            var finances = db.Finances.Include(f => f.AssetEntry).Include(f => f.Vendor);
            return View(finances.ToList());
        }

        // GET: Finances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finance finance = db.Finances.Find(id);
            if (finance == null)
            {
                return HttpNotFound();
            }
            return View(finance);
        }

        // GET: Finances/Create
        public ActionResult Create()
        {
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId");
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "VendorName");
            return View();
        }

        // POST: Finances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssetEntryId,VendorId,ParchasePrice,ParchaseOrderNo,PurchaseDate")] Finance finance)
        {
            if (ModelState.IsValid)
            {
                db.Finances.Add(finance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", finance.AssetEntryId);
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "VendorName", finance.VendorId);
            return View(finance);
        }

        // GET: Finances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finance finance = db.Finances.Find(id);
            if (finance == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", finance.AssetEntryId);
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "VendorName", finance.VendorId);
            return View(finance);
        }

        // POST: Finances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssetEntryId,VendorId,ParchasePrice,ParchaseOrderNo,PurchaseDate")] Finance finance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", finance.AssetEntryId);
            ViewBag.VendorId = new SelectList(db.Vendors, "Id", "VendorName", finance.VendorId);
            return View(finance);
        }

        // GET: Finances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finance finance = db.Finances.Find(id);
            if (finance == null)
            {
                return HttpNotFound();
            }
            return View(finance);
        }

        // POST: Finances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Finance finance = db.Finances.Find(id);
            db.Finances.Remove(finance);
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
