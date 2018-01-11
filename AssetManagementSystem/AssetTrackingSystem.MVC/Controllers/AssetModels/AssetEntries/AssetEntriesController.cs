using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.AssetModelManagers.AssetEntryManagers;
using Asset.BisnessLogic.Library.AssetModelManagers.AssetSetupManagers;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.AssetsModels.AssetEntrys;
using AssetSqlDatabase.Library.DatabaseContext;

namespace AssetTrackingSystem.MVC.Controllers.AssetModels.AssetEntries
{
    public class AssetEntriesController : Controller
    {
        private readonly AssetEntryManager _assetEntryManager;
        private readonly OrganizationManager _organizationManager;
        private readonly BranchManager _branchManager;
        private readonly AssetLocationManager _assetLocationManager;
        private readonly AssetTypeManager _assetTypeManager;
        private readonly AssetGroupManager _assetGroupManager;
        private readonly AssetManufactureManager _assetManufactureManager;
        private readonly AssetModelManager _assetModelManager;

        private readonly AssetDbContext _db = new AssetDbContext();

        public AssetEntriesController()
        {
            _assetEntryManager = new AssetEntryManager();
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
            _assetLocationManager = new AssetLocationManager();
            _assetTypeManager = new AssetTypeManager();
            _assetGroupManager = new AssetGroupManager();
            _assetManufactureManager = new AssetManufactureManager();
            _assetModelManager=new AssetModelManager();
        }

        // GET: AssetEntries
        public ActionResult Index()
        {
            var assetEntries = _db.AssetEntries.Include(a => a.AssetGroup).Include(a => a.AssetLocation).Include(a => a.AssetManufacurer).Include(a => a.AssetModel).Include(a => a.AssetType).Include(a => a.Branch).Include(a => a.Organization);
            return View(assetEntries.ToList());
        }

        // GET: AssetEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetEntry assetEntry = _db.AssetEntries.Find(id);
            if (assetEntry == null)
            {
                return HttpNotFound();
            }
            return View(assetEntry);
        }

        // GET: AssetEntries/Create
        public ActionResult Create()
        {
            ViewBag.AssetGroupId = new SelectList(_db.AssetGroups, "Id", "Name");
            ViewBag.AssetLocationId = new SelectList(_db.AssetLocations, "Id", "Name");
            ViewBag.AssetManufacurerId = new SelectList(_db.AssetManufacurers, "Id", "Name");
            ViewBag.AssetModelId = new SelectList(_db.AssetModels, "Id", "Name");
            ViewBag.AssetTypeId = new SelectList(_db.AssetTypes, "Id", "Name");
            ViewBag.BranchId = new SelectList(_db.Branches, "Id", "Name");
            ViewBag.OrganizationId = new SelectList(_db.Organizations, "Id", "Name");
            return View();
        }

        // POST: AssetEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationId,BranchId,AssetLocationId,AssetTypeId,AssetGroupId,AssetManufacurerId,AssetModelId,AssetId,Name,SerialNo,Status,Attachment")] AssetEntry assetEntry)
        {
            if (ModelState.IsValid)
            {
                _db.AssetEntries.Add(assetEntry);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssetGroupId = new SelectList(_db.AssetGroups, "Id", "Name", assetEntry.AssetGroupId);
            ViewBag.AssetLocationId = new SelectList(_db.AssetLocations, "Id", "Name", assetEntry.AssetLocationId);
            ViewBag.AssetManufacurerId = new SelectList(_db.AssetManufacurers, "Id", "Name", assetEntry.AssetManufacurerId);
            ViewBag.AssetModelId = new SelectList(_db.AssetModels, "Id", "Name", assetEntry.AssetModelId);
            ViewBag.AssetTypeId = new SelectList(_db.AssetTypes, "Id", "Name", assetEntry.AssetTypeId);
            ViewBag.BranchId = new SelectList(_db.Branches, "Id", "Name", assetEntry.BranchId);
            ViewBag.OrganizationId = new SelectList(_db.Organizations, "Id", "Name", assetEntry.OrganizationId);
            return View(assetEntry);
        }

        // GET: AssetEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetEntry assetEntry = _db.AssetEntries.Find(id);
            if (assetEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetGroupId = new SelectList(_db.AssetGroups, "Id", "Name", assetEntry.AssetGroupId);
            ViewBag.AssetLocationId = new SelectList(_db.AssetLocations, "Id", "Name", assetEntry.AssetLocationId);
            ViewBag.AssetManufacurerId = new SelectList(_db.AssetManufacurers, "Id", "Name", assetEntry.AssetManufacurerId);
            ViewBag.AssetModelId = new SelectList(_db.AssetModels, "Id", "Name", assetEntry.AssetModelId);
            ViewBag.AssetTypeId = new SelectList(_db.AssetTypes, "Id", "Name", assetEntry.AssetTypeId);
            ViewBag.BranchId = new SelectList(_db.Branches, "Id", "Name", assetEntry.BranchId);
            ViewBag.OrganizationId = new SelectList(_db.Organizations, "Id", "Name", assetEntry.OrganizationId);
            return View(assetEntry);
        }

        // POST: AssetEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganizationId,BranchId,AssetLocationId,AssetTypeId,AssetGroupId,AssetManufacurerId,AssetModelId,AssetId,Name,SerialNo,Status,Attachment")] AssetEntry assetEntry)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(assetEntry).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssetGroupId = new SelectList(_db.AssetGroups, "Id", "Name", assetEntry.AssetGroupId);
            ViewBag.AssetLocationId = new SelectList(_db.AssetLocations, "Id", "Name", assetEntry.AssetLocationId);
            ViewBag.AssetManufacurerId = new SelectList(_db.AssetManufacurers, "Id", "Name", assetEntry.AssetManufacurerId);
            ViewBag.AssetModelId = new SelectList(_db.AssetModels, "Id", "Name", assetEntry.AssetModelId);
            ViewBag.AssetTypeId = new SelectList(_db.AssetTypes, "Id", "Name", assetEntry.AssetTypeId);
            ViewBag.BranchId = new SelectList(_db.Branches, "Id", "Name", assetEntry.BranchId);
            ViewBag.OrganizationId = new SelectList(_db.Organizations, "Id", "Name", assetEntry.OrganizationId);
            return View(assetEntry);
        }

        // GET: AssetEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetEntry assetEntry = _db.AssetEntries.Find(id);
            if (assetEntry == null)
            {
                return HttpNotFound();
            }
            return View(assetEntry);
        }

        // POST: AssetEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetEntry assetEntry = _db.AssetEntries.Find(id);
            _db.AssetEntries.Remove(assetEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
