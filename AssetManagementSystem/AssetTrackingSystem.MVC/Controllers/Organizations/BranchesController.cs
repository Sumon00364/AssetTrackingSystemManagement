using System.Linq;
using System.Net;
using System.Web.Mvc;
using Asset.BisnessLogic.Library.Organizations;
using Asset.Models.Library.EntityModels.OrganizationModels;

namespace AssetTrackingSystem.MVC.Controllers.Organizations
{
    [Authorize]
    public class BranchesController : Controller
    {
        private readonly OrganizationManager _organizationManager;
        private readonly BranchManager _branchManager;
        public BranchesController()
        {
            _organizationManager = new OrganizationManager();
            _branchManager = new BranchManager();
        }

        // GET: Branches
        public ActionResult Index()
        {
            var branches = _branchManager.GetBranchWithOrganization();
            return View(branches.ToList());
        }

        // GET: Branches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Branch branch = _branchManager.SingleBranch((int)id);

            if (branch == null)
            {
                return HttpNotFound();
            }

            return View(branch);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Branches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrganizationId,Name,ShortName,BranchCode")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                bool isBranchName = _branchManager.IsBranchNameExist(branch.Name);
                bool isBranchShortName = _branchManager.IsBranchShortNameExist(branch.ShortName);
                bool isBranchCode = _branchManager.IsBranchCodeExist(branch.BranchCode);
                if (isBranchName)
                {
                    ViewBag.NameCssClass = "Alert Alert-warning";
                    ViewBag.NameMessageType = "Warning";
                    ViewBag.NameMessage = "This branch name is already exist!";
                }
                else if (isBranchShortName)
                {
                    ViewBag.ShortNameCssClass = "Alert Alert-warning";
                    ViewBag.ShortNameMessageType = "Warning";
                    ViewBag.ShortNameMessage = "This branch short-name is already exist!";
                }
                else if (isBranchCode)
                {
                    ViewBag.CodeCssClass = "Alert Alert-warning";
                    ViewBag.CodeMessageType = "Warning";
                    ViewBag.CodeMessage = "This branch code is already exist!";
                }
                else
                {
                    _branchManager.Add(branch);
                    return RedirectToAction("Index");
                }
            }

            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", branch.OrganizationId);

            return View(branch);
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Branch branch = _branchManager.SingleBranch((int)id);

            if (branch == null)
            {
                return HttpNotFound();
            }

            ViewBag.OrganizationId = new SelectList(_organizationManager.GetAll(), "Id", "Name", branch.OrganizationId);

            return View(branch);
        }

        // POST: Branches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrganizationId,Name,ShortName,BranchCode")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                _branchManager.Update(branch);
                return RedirectToAction("Index");
            }

            ViewBag.OrganizationId = new SelectList(_branchManager.GetAll(), "Id", "Name", branch.OrganizationId);

            return View(branch);
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Branch branch = _branchManager.SingleBranch((int)id);

            if (branch == null)
            {
                return HttpNotFound();
            }

            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch branch = _branchManager.SingleBranch(id);
            if (branch != null) _branchManager.Remove(branch);

            return RedirectToAction("Index");
        }
    }
}
