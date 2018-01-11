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
    public class AssetGroupsController : Controller
    {
        private AssetDbContext db = new AssetDbContext();

        // GET: AssetGroups
        public ActionResult Index()
        {
            var assetGroups = db.AssetGroups.Include(a => a.AssetType);
            return View(assetGroups.ToList());
        }

        // GET: AssetGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetGroup assetGroup = db.AssetGroups.Find(id);
            if (assetGroup == null)
            {
                return HttpNotFound();
            }
            return View(assetGroup);
        }

        // GET: AssetGroups/Create
        public ActionResult Create()
        {
            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name");
            return View();
        }

        // POST: AssetGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssetTypeId,Name,ShortName,GroupCode")] AssetGroup assetGroup)
        {
            if (ModelState.IsValid)
            {
                db.AssetGroups.Add(assetGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name", assetGroup.AssetTypeId);
            return View(assetGroup);
        }

        // GET: AssetGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetGroup assetGroup = db.AssetGroups.Find(id);
            if (assetGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name", assetGroup.AssetTypeId);
            return View(assetGroup);
        }

        // POST: AssetGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssetTypeId,Name,ShortName,GroupCode")] AssetGroup assetGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assetGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetTypeId = new SelectList(db.AssetTypes, "Id", "Name", assetGroup.AssetTypeId);
            return View(assetGroup);
        }

        // GET: AssetGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetGroup assetGroup = db.AssetGroups.Find(id);
            if (assetGroup == null)
            {
                return HttpNotFound();
            }
            return View(assetGroup);
        }

        // POST: AssetGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetGroup assetGroup = db.AssetGroups.Find(id);
            db.AssetGroups.Remove(assetGroup);
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
