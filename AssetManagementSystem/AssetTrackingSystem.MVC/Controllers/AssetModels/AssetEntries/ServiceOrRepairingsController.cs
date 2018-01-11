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
    public class ServiceOrRepairingsController : Controller
    {
        private AssetDbContext db = new AssetDbContext();

        // GET: ServiceOrRepairings
        public ActionResult Index()
        {
            var serviceOrRepairings = db.ServiceOrRepairings.Include(s => s.AssetEntry);
            return View(serviceOrRepairings.ToList());
        }

        // GET: ServiceOrRepairings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrRepairing serviceOrRepairing = db.ServiceOrRepairings.Find(id);
            if (serviceOrRepairing == null)
            {
                return HttpNotFound();
            }
            return View(serviceOrRepairing);
        }

        // GET: ServiceOrRepairings/Create
        public ActionResult Create()
        {
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId");
            return View();
        }

        // POST: ServiceOrRepairings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssetEntryId,Description,ServiceDate,ServiceingCostDecimal,PartsCostDecimal,TaxDecimal,ServiceBy")] ServiceOrRepairing serviceOrRepairing)
        {
            if (ModelState.IsValid)
            {
                db.ServiceOrRepairings.Add(serviceOrRepairing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", serviceOrRepairing.AssetEntryId);
            return View(serviceOrRepairing);
        }

        // GET: ServiceOrRepairings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrRepairing serviceOrRepairing = db.ServiceOrRepairings.Find(id);
            if (serviceOrRepairing == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", serviceOrRepairing.AssetEntryId);
            return View(serviceOrRepairing);
        }

        // POST: ServiceOrRepairings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssetEntryId,Description,ServiceDate,ServiceingCostDecimal,PartsCostDecimal,TaxDecimal,ServiceBy")] ServiceOrRepairing serviceOrRepairing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceOrRepairing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", serviceOrRepairing.AssetEntryId);
            return View(serviceOrRepairing);
        }

        // GET: ServiceOrRepairings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrRepairing serviceOrRepairing = db.ServiceOrRepairings.Find(id);
            if (serviceOrRepairing == null)
            {
                return HttpNotFound();
            }
            return View(serviceOrRepairing);
        }

        // POST: ServiceOrRepairings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceOrRepairing serviceOrRepairing = db.ServiceOrRepairings.Find(id);
            db.ServiceOrRepairings.Remove(serviceOrRepairing);
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
