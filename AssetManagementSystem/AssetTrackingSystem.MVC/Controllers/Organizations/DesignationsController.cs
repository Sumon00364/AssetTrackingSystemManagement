using System.Linq;
using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace AssetTrackingSystem.MVC.Controllers.Organizations
{
    [Authorize]
    public class DesignationsController : Controller
    {
        private readonly DepartmentManager _departmentManager;
        private readonly DesignationManager _designationManager;
        public DesignationsController()
        {
            _departmentManager = new DepartmentManager();
            _designationManager = new DesignationManager();
        }

        // GET: Designations
        public ActionResult Index()
        {
            var designations = _designationManager.DesignationWithDepartment();
            return View(designations.ToList());
        }

        // GET: Designations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Designation designation = _designationManager.SingleDesignation((int)id);

            if (designation == null)
            {
                return HttpNotFound();
            }

            return View(designation);
        }

        // GET: Designations/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Designations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DepartmentId,Name,ShortName")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                bool isName = _designationManager.IsDesignationNameExist(designation.Name);
                bool isShortName = _designationManager.IsDesignationShortNameExist(designation.ShortName);

                if (isName)
                {
                    ViewBag.NameCssClass = "Alert Alert-warning";
                    ViewBag.NameMessageType = "Warning";
                    ViewBag.NameMessage = "This designation name already exist!";
                }
                else if (isShortName)
                {
                    ViewBag.ShortNameCssClass = "Alert Alert-warning";
                    ViewBag.ShortNameMessageType = "Warning";
                    ViewBag.ShortNameMessage = "This designation short-name already exist!";
                }
                else
                {
                    _designationManager.Add(designation);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", designation.DepartmentId);

            return View(designation);
        }

        // GET: Designations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Designation designation = _designationManager.SingleDesignation((int)id);

            if (designation == null)
            {
                return HttpNotFound();
            }

            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", designation.DepartmentId);

            return View(designation);
        }

        // POST: Designations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartmentId,Name,ShortName")] Designation designation)
        {
            if (ModelState.IsValid)
            {
                _designationManager.Update(designation);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", designation.DepartmentId);
            return View(designation);
        }

        // GET: Designations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Designation designation = _designationManager.SingleDesignation((int)id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Designation designation = _designationManager.SingleDesignation(id);
            if (designation != null) _designationManager.Remove(designation);
            return RedirectToAction("Index");
        }
    }
}
