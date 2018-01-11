using System.Linq;
using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace AssetTrackingSystem.MVC.Controllers.Organizations
{
    [Authorize]
    public class OrganizationsController : Controller
    {
        private readonly OrganizationManager _organizationManager;
        public OrganizationsController()
        {
            _organizationManager = new OrganizationManager();
        }

        // GET: Organizations
        public ActionResult Index()
        {
            var organizations = _organizationManager.GetAll();
            return View(organizations.ToList());
        }

        // GET: Organizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Organization organization = _organizationManager.SingleOrganization((int)id);

            if (organization == null)
            {
                return HttpNotFound();
            }

            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortName,Location,Description")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                bool isName = _organizationManager.IsOrganizationNameExist(organization.Name);
                bool isShortName = _organizationManager.IsShortNameExist(organization.ShortName);

                if (isName)
                {
                    ViewBag.NameCssClass = "Alert Alert-warning";
                    ViewBag.NameMessageType = "Warning";
                    ViewBag.Message = "This orgaization name already exist!";
                }
                else if (isShortName)
                {
                    ViewBag.ShortNameCssClass = "Alert Alert-warning";
                    ViewBag.ShortNameMessageType = "Warning";
                    ViewBag.ShortNameMessage = "This organization short-name already exist!";
                }
                else
                {
                    _organizationManager.Add(organization);
                    return RedirectToAction("Index");
                }
            }

            return View(organization);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Organization organization = _organizationManager.SingleOrganization((int)id);

            if (organization == null)
            {
                return HttpNotFound();
            }

            return View(organization);
        }

        // POST: Organizations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortName,Location,Description")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                _organizationManager.Update(organization);
                return RedirectToAction("Index");
            }
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Organization organization = _organizationManager.SingleOrganization((int)id);

            if (organization == null)
            {
                return HttpNotFound();
            }

            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organization organization = _organizationManager.SingleOrganization(id);

            if (organization != null) _organizationManager.Remove(organization);

            return RedirectToAction("Index");
        }
    }
}
