using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;
using AssetSqlDatabase.Library.DatabaseContext;

namespace AssetTrackingSystem.MVC.Controllers.AssetModels.AssetSetups
{
    public class AssetModelsController : Controller
    {
        private AssetDbContext db = new AssetDbContext();

        // GET: AssetModels
        public ActionResult Index()
        {
            var assetModels = db.AssetModels.Include(a => a.AssetGroup).Include(a => a.AssetManufacurer);
            return View(assetModels.ToList());
        }

        // GET: AssetModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetModel assetModel = db.AssetModels.Find(id);
            if (assetModel == null)
            {
                return HttpNotFound();
            }
            return View(assetModel);
        }

        // GET: AssetModels/Create
        public ActionResult Create()
        {
            ViewBag.AssetGroupId = new SelectList(db.AssetGroups, "Id", "Name");
            ViewBag.AssetManufacurerId = new SelectList(db.AssetManufacurers, "Id", "Name");
            return View();
        }

        // POST: AssetModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssetGroupId,AssetManufacurerId,Name,ShortName,Code,Description")] AssetModel assetModel)
        {
            if (ModelState.IsValid)
            {
                db.AssetModels.Add(assetModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetGroupId = new SelectList(db.AssetGroups, "Id", "Name", assetModel.AssetGroupId);
            ViewBag.AssetManufacurerId = new SelectList(db.AssetManufacurers, "Id", "Name", assetModel.AssetManufacurerId);
            return View(assetModel);
        }

        // GET: AssetModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetModel assetModel = db.AssetModels.Find(id);
            if (assetModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetGroupId = new SelectList(db.AssetGroups, "Id", "Name", assetModel.AssetGroupId);
            ViewBag.AssetManufacurerId = new SelectList(db.AssetManufacurers, "Id", "Name", assetModel.AssetManufacurerId);
            return View(assetModel);
        }

        // POST: AssetModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssetGroupId,AssetManufacurerId,Name,ShortName,Code,Description")] AssetModel assetModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetGroupId = new SelectList(db.AssetGroups, "Id", "Name", assetModel.AssetGroupId);
            ViewBag.AssetManufacurerId = new SelectList(db.AssetManufacurers, "Id", "Name", assetModel.AssetManufacurerId);
            return View(assetModel);
        }

        // GET: AssetModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetModel assetModel = db.AssetModels.Find(id);
            if (assetModel == null)
            {
                return HttpNotFound();
            }
            return View(assetModel);
        }

        // POST: AssetModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetModel assetModel = db.AssetModels.Find(id);
            db.AssetModels.Remove(assetModel);
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
