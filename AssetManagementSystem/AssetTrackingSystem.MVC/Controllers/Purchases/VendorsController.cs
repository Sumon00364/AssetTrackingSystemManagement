using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.AssetModelManagers.Purchases;
using Asset.Models.Library.EntityModels.Purchases;

namespace AssetTrackingSystem.MVC.Controllers.Purchases
{
    public class VendorsController : Controller
    {
        private readonly VendorManager _vendorManager;
        public VendorsController()
        {
            _vendorManager = new VendorManager();
        }



        // GET: Vendors
        public ActionResult Index()
        {
            var vendors = _vendorManager.GetAll();
            return View(vendors);
        }


        // GET: Vendors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.SingleVendor((int)id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // GET: Vendors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VendorName,VendorShortName,ContactNo,Email,Address,Comments")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _vendorManager.Add(vendor);
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        // GET: Vendors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.SingleVendor((int)id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VendorName,VendorShortName,ContactNo,Email,Address,Comments")] Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                _vendorManager.Update(vendor);
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        // GET: Vendors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendor vendor = _vendorManager.SingleVendor((int)id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        // POST: Vendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = _vendorManager.SingleVendor(id);
            if (vendor != null) _vendorManager.Remove(vendor);
            return RedirectToAction("Index");
        }
    }
}
