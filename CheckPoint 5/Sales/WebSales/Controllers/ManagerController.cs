using System.Linq;
using System.Net;
using System.Web.Mvc;
using WatcherModel;
using WatcherModel.Repository;

namespace WebSales.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        // GET: Manager
        private UnitOfWork _unit = new UnitOfWork(new ModelContainer());
        private IRepository<Manager> repo;

        public ManagerController()
        {
            repo=_unit.ReposManager;
        }

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        [HttpPost]
        public ActionResult SearchManager(string name)
        {
            var manager= repo.SearchFor(a => a.FirstName.Contains(name)).ToList();
            if (manager.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(manager);
        }
        // GET: Manager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var managerSet = repo.GetById((int)id);
                if (managerSet == null)
                {
                    return HttpNotFound();
                }
                return View(managerSet);
            }
        }

        // GET: Manager/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,FirstName,SecondName")] Manager managerSet)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(managerSet);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View(managerSet);
        }

        // GET: Manager/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var managerSet = repo.GetById((int)id);
            if (managerSet == null)
            {
                return HttpNotFound();
            }
            return View(managerSet);
        }

        // POST: Manager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,FirstName,SecondName")] Manager managerSet)
        {
            if (ModelState.IsValid)
            {
                repo.Update(managerSet);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View(managerSet);
        }

        // GET: Manager/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var managerSet = repo.GetById((int)id);
            if (managerSet == null)
            {
                return HttpNotFound();
            }
            return View(managerSet);
        }

        // POST: Manager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var managerSet = repo.GetById(id);
                repo.Delete(managerSet);
                _unit.Save();
                return RedirectToAction("Index");
            }
            catch 
            {
                ViewBag.Error = "No deleted!";
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
