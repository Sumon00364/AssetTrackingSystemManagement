using System.Linq;
using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace AssetTrackingSystem.MVC.Controllers.Organizations
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly OrganizationManager _organizationManager;
        private readonly DepartmentManager _departmentManager;
        public DepartmentsController()
        {
            _organizationManager = new OrganizationManager();
            _departmentManager = new DepartmentManager();
        }

        // GET: Departments
        public ActionResult Index()
        {
            var departments = _departmentManager.DepartmentWithOrganization();
            return View(departments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Department department = _departmentManager.SingleDepartment((int)id);

            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationId,Name,ShortName,DepartmentCode")] Department department)
        {
            if (ModelState.IsValid)
            {
                bool isName = _departmentManager.IsDepartmentNameExist(department.Name);
                bool isShortName = _departmentManager.IsDepartmentShortNameExist(department.ShortName);
                bool isCode = _departmentManager.IsDepartmentCodeExist(department.DepartmentCode);

                if (isName)
                {
                    ViewBag.NameCssClass = "Alert Alert-warning";
                    ViewBag.NameMessageType = "Warning";
                    ViewBag.NameMEssage = "This department name is already exist!";
                }
                else if (isShortName)
                {
                    ViewBag.ShortNameCssClass = "Alert Alert-warning";
                    ViewBag.ShortNameMessageType = "Warning";
                    ViewBag.ShortNameMessage = "This department short name is already exist!";
                }
                else if (isCode)
                {
                    ViewBag.CodeCssClass = "Alert Alert-warning";
                    ViewBag.CodeMessageType = "Warning";
                    ViewBag.CodeMessage = "This department code is already exist!";
                }
                else
                {
                    _departmentManager.Add(department);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", department.OrganizationId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Department department = _departmentManager.SingleDepartment((int)id);

            if (department == null)
            {
                return HttpNotFound();
            }

            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", department.OrganizationId);

            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganizationId,Name,ShortName,DepartmentCode")] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentManager.Update(department);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", department.OrganizationId);

            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Department department = _departmentManager.SingleDepartment((int)id);

            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = _departmentManager.SingleDepartment(id);

            if (department != null) _departmentManager.Remove(department);

            return RedirectToAction("Index");
        }
    }
}
