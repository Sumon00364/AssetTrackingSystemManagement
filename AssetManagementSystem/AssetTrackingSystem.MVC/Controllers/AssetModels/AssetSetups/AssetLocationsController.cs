using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.AssetModelManagers.AssetSetupManagers;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;

namespace AssetTrackingSystem.MVC.Controllers.AssetModels.AssetSetups
{
    public class AssetLocationsController : Controller
    {
        private readonly AssetLocationManager _assetLocationManager;
        private readonly OrganizationManager _organizationManager;
        private readonly BranchManager _branchManager;
        public AssetLocationsController()
        {
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
            _assetLocationManager = new AssetLocationManager();
        }


        // GET: AssetLocations
        public ActionResult Index()
        {
            var assetLocations = _assetLocationManager.AssetLocationsWithOrganizationAndBranch();
            return View(assetLocations);
        }

        // GET: AssetLocations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = _assetLocationManager.SingleAssetLocation((int) id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            return View(assetLocation);
        }

        // GET: AssetLocations/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(_branchManager.GetAll(), "Id", "Name");
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: AssetLocations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationId,BranchId,Name,ShortName,AssetLocationCode")] AssetLocation assetLocation)
        {
            if (ModelState.IsValid)
            {
                bool isName = _assetLocationManager.IsAssetLocationNameExist(assetLocation.Name);
                bool isShortName = _assetLocationManager.IsAssetLocatoinShortNameExist(assetLocation.ShortName);
                bool isCode = _assetLocationManager.IsAssetLocationByCodeExist(assetLocation.AssetLocationCode);

                if (isName)
                {
                    ViewBag.NameCssClass = "Alert Alert-warning";
                    ViewBag.NameMessageType = "Warning";
                    ViewBag.NameMessage = "This Asset Location already exist";
                }
                else if (isShortName)
                {
                    ViewBag.ShortNameCssClass = "Alert Alert-warning";
                    ViewBag.ShortNameMessageType = "Warning";
                    ViewBag.ShortNameMessage = "This asset location short name already exist!";
                }
                else if (isCode)
                {
                    ViewBag.CodeCssClass = "Alert Alert-warning";
                    ViewBag.MessageType = "Warning";
                    ViewBag.Message = "This asset location code already exist!";
                }
                else
                {
                    _assetLocationManager.Add(assetLocation);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.BranchId = new SelectList(_branchManager.GetAll(), "Id", "Name", assetLocation.BranchId);
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", assetLocation.OrganizationId);
            return View(assetLocation);
        }

        // GET: AssetLocations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = _assetLocationManager.SingleAssetLocation((int) id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(_branchManager.GetAll(), "Id", "Name", assetLocation.BranchId);
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", assetLocation.OrganizationId);
            return View(assetLocation);
        }

        // POST: AssetLocations/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganizationId,BranchId,Name,ShortName,AssetLocationCode")] AssetLocation assetLocation)
        {
            if (ModelState.IsValid)
            {
                _assetLocationManager.Update(assetLocation);
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(_branchManager.GetAll(), "Id", "Name", assetLocation.BranchId);
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", assetLocation.OrganizationId);
            return View(assetLocation);
        }

        // GET: AssetLocations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetLocation assetLocation = _assetLocationManager.SingleAssetLocation((int) id);
            if (assetLocation == null)
            {
                return HttpNotFound();
            }
            return View(assetLocation);
        }

        // POST: AssetLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetLocation assetLocation = _assetLocationManager.SingleAssetLocation(id);
            if(assetLocation != null) _assetLocationManager.Remove(assetLocation);
            return RedirectToAction("Index");
        }
    }
}
