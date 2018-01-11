using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.AssetModelManagers.AssetSetupManagers;
using Asset.Models.Library.EntityModels.AssetsModels.AssetSetups;

namespace AssetTrackingSystem.MVC.Controllers.AssetModels.AssetSetups
{
    [Authorize]
    public class AssetManufacurersController : Controller
    {
        private readonly AssetManufactureManager _assetManufactureManager;
        private readonly AssetGroupManager _assetGroupManager;
        public AssetManufacurersController()
        {
            _assetManufactureManager = new AssetManufactureManager();
            _assetGroupManager = new AssetGroupManager();
        }



        // GET: AssetManufacurers
        public ActionResult Index()
        {
            var assetManufacurers = _assetManufactureManager.AssetManufacurersWithAssetGroup();
            return View(assetManufacurers);
        }

        // GET: AssetManufacurers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetManufacurer assetManufacurer = _assetManufactureManager.SingleAssetManufacurer((int) id);
            if (assetManufacurer == null)
            {
                return HttpNotFound();
            }
            return View(assetManufacurer);
        }

        // GET: AssetManufacurers/Create
        public ActionResult Create()
        {
            ViewBag.AssetGroupId = new SelectList(_assetGroupManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: AssetManufacurers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AssetGroupId,Name,ShortName,Code,Description")] AssetManufacurer assetManufacurer)
        {
            if (ModelState.IsValid)
            {
                bool isName = _assetManufactureManager.IsAssetManufactureNameExist(assetManufacurer.Name);
                bool isShortName =
                    _assetManufactureManager.AssetManufactureByShortNameExist(assetManufacurer.ShortName);
                bool isCode = _assetManufactureManager.IsAssetManufactureCodeExist(assetManufacurer.Code);

                if (isName)
                {
                    ViewBag.NameCssClass = "Alert Alert-warning";
                    ViewBag.NameMessageType = "Warning";
                    ViewBag.NameMessage = "This asset manufacturer name already exist!";
                }
                else if (isShortName)
                {
                    ViewBag.ShortNameCssClass = "Alert Alert-warning";
                    ViewBag.ShortNameMessageType = "Warning";
                    ViewBag.ShortNameMessage = "This asst manufacturer short-name already exist!";
                }
                else if (isCode)
                {
                    ViewBag.CodeCssClass = "Alert Alert-warning";
                    ViewBag.MessageType = "Warning";
                    ViewBag.Message = "This asset manufacturer code already exist!";
                }
                else
                {
                    _assetManufactureManager.Add(assetManufacurer);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.AssetGroupId = new SelectList(_assetGroupManager.GetAll(), "Id", "Name", assetManufacurer.AssetGroupId);
            return View(assetManufacurer);
        }

        // GET: AssetManufacurers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetManufacurer assetManufacurer = _assetManufactureManager.SingleAssetManufacurer((int) id);
            if (assetManufacurer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssetGroupId = new SelectList(_assetGroupManager.GetAll(), "Id", "Name", assetManufacurer.AssetGroupId);
            return View(assetManufacurer);
        }

        // POST: AssetManufacurers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AssetGroupId,Name,ShortName,Code,Description")] AssetManufacurer assetManufacurer)
        {
            if (ModelState.IsValid)
            {
                _assetManufactureManager.Update(assetManufacurer);
                return RedirectToAction("Index");
            }
            ViewBag.AssetGroupId = new SelectList(_assetGroupManager.GetAll(), "Id", "Name", assetManufacurer.AssetGroupId);
            return View(assetManufacurer);
        }

        // GET: AssetManufacurers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssetManufacurer assetManufacurer = _assetManufactureManager.SingleAssetManufacurer((int) id);
            if (assetManufacurer == null)
            {
                return HttpNotFound();
            }
            return View(assetManufacurer);
        }

        // POST: AssetManufacurers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssetManufacurer assetManufacurer = _assetManufactureManager.SingleAssetManufacurer(id);
            if(assetManufacurer != null) _assetManufactureManager.Remove(assetManufacurer);
            return RedirectToAction("Index");
        }
    }
}
