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
    public class AttchmentsController : Controller
    {
        private AssetDbContext db = new AssetDbContext();

        // GET: Attchments
        public ActionResult Index()
        {
            var attchments = db.Attchments.Include(a => a.AssetEntry);
            return View(attchments.ToList());
        }

        // GET: Attchments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attchment attchment = db.Attchments.Find(id);
            if (attchment == null)
            {
                return HttpNotFound();
            }
            return View(attchment);
        }

        // GET: Attchments/Create
        public ActionResult Create()
        {
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId");
            return View();
        }

        // POST: Attchments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssetEntryId,File")] Attchment attchment)
        {
            if (ModelState.IsValid)
            {
                db.Attchments.Add(attchment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", attchment.AssetEntryId);
            return View(attchment);
        }

        // GET: Attchments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attchment attchment = db.Attchments.Find(id);
            if (attchment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", attchment.AssetEntryId);
            return View(attchment);
        }

        // POST: Attchments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssetEntryId,File")] Attchment attchment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attchment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetEntryId = new SelectList(db.AssetEntries, "Id", "AssetId", attchment.AssetEntryId);
            return View(attchment);
        }

        // GET: Attchments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attchment attchment = db.Attchments.Find(id);
            if (attchment == null)
            {
                return HttpNotFound();
            }
            return View(attchment);
        }

        // POST: Attchments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attchment attchment = db.Attchments.Find(id);
            db.Attchments.Remove(attchment);
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
