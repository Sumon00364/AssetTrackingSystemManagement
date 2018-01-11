using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.HRMs;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.HrModels;

namespace AssetTrackingSystem.MVC.Controllers.HRMs
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeManager _employeeManager;
        private readonly OrganizationManager _organizationManager;
        private readonly BranchManager _branchManager;
        private readonly DepartmentManager _departmentManager;
        private readonly DesignationManager _designationManager;
        public EmployeesController()
        {
            _employeeManager = new EmployeeManager();
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
            _departmentManager = new DepartmentManager();
            _designationManager = new DesignationManager();
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employees = _employeeManager.EmployeesWithOrganizationBrnachDepartmentAndDdesignation();
            return View(employees);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.SingleEmployee((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(_branchManager.GetAll(), "Id", "Name");
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            ViewBag.DesignationId = new SelectList(_designationManager.GetAll(), "Id", "Name");
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationId,BranchId,DepartmentId,DesignationId,FirstName,LastName,ContactNo,Email,Address,Image,Code")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                bool isFirstName = _employeeManager.IsFirstNameExist(employee.FirstName);
                bool isLastName = _employeeManager.IsLastNameExist(employee.LastName);
                bool isEmail = _employeeManager.IsEmailExist(employee.Email);
                bool isCode = _employeeManager.IsEmployeeCodeExist(employee.Code);

                if (isFirstName)
                {
                    ViewBag.FirstNameCssClass = "Alert Alert-warning";
                    ViewBag.FirstNameMessageType = "Warning";
                    ViewBag.FirstNameMEssage = "This Employee first name is already exist!";
                }
                else if (isLastName)
                {
                    ViewBag.LastNameCssClass = "Alert Alert-warning";
                    ViewBag.LastNameMessageType = "Warning";
                    ViewBag.LastNameMessage = "This Employee last name already exist!";
                }
                else if (isEmail)
                {
                    ViewBag.EmailClassClass = "Alert Alert-Warning";
                    ViewBag.EmailMessageType = "Warning";
                    ViewBag.EmailMessage = "This employee email address already exist!";
                }
                else if (isCode)
                {
                    ViewBag.CodeCssClass = "Alert Alert-warning";
                    ViewBag.CodeMessageType = "Warning";
                    ViewBag.CodeMessage = "This Employee code already exist!";
                }
                else
                {
                    _employeeManager.Add(employee);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.BranchId = new SelectList(_branchManager.GetAll(), "Id", "Name", employee.BranchId);
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(_designationManager.GetAll(), "Id", "Name", employee.DesignationId);
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", employee.OrganizationId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.SingleEmployee((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(_branchManager.GetAll(), "Id", "Name", employee.BranchId);
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(_designationManager.GetAll(), "Id", "Name", employee.DesignationId);
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", employee.OrganizationId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganizationId,BranchId,DepartmentId,DesignationId,FirstName,LastName,ContactNo,Email,Address,Image,Code")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeManager.Update(employee);
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(_branchManager.GetAll(), "Id", "Name", employee.BranchId);
            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.DesignationId = new SelectList(_designationManager.GetAll(), "Id", "Name", employee.DesignationId);
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", employee.OrganizationId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employeeManager.SingleEmployee((int) id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _employeeManager.SingleEmployee(id);
            if(employee != null) _employeeManager.Remove(employee);
            return RedirectToAction("Index");
        }
    }
}
