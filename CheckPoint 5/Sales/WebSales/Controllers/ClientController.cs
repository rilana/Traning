using System.Linq;
using System.Net;
using System.Web.Mvc;
using WatcherModel;
using WatcherModel.Repository;

namespace WebSales.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Client
        private UnitOfWork _unit = new UnitOfWork(new ModelContainer());
       
        public ActionResult Index()
        {
            return View(_unit.ReposClient.GetAll());
        }

        [HttpPost]
        public ActionResult SearchClient(string name)
        {
            var client = _unit.ReposClient.SearchFor(a => a.FirstName.Contains(name)).ToList();
            if (client.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(client);
        }
        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var clientSet = _unit.ReposClient.GetById((int)id);
                if (clientSet == null)
                {
                    return HttpNotFound();
                }
                return View(clientSet);
            }
        }

        // GET: Client/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
       [Authorize(Roles = "admin")]
       public ActionResult Create([Bind(Include = "Id,FirstName,SecondName")] Client clientSet)
        {
            if (ModelState.IsValid)
            {
                _unit.ReposClient.Insert(clientSet);
                _unit.Save();
                return RedirectToAction("Index");
            }

            return View(clientSet);
        }

       // GET: Client/Edit/5
       [Authorize(Roles = "admin")]
       public ActionResult Edit(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           var clientSet =  _unit.ReposClient.GetById((int)id);
           if (clientSet == null)
           {
               return HttpNotFound();
           }
           return View(clientSet);
       }

       // POST: Client/Edit/5
       [HttpPost]
       [ValidateAntiForgeryToken]
       [Authorize(Roles = "admin")]
       public ActionResult Edit([Bind(Include = "Id,FirstName,SecondName")] Client clientSet)
       {
           if (ModelState.IsValid)
           {
               _unit.ReposClient.Update(clientSet);
               _unit.Save();
               return RedirectToAction("Index");
           }
           return View(clientSet);
       }

       // GET: Client/Delete/5
       [Authorize(Roles = "admin")]
       public ActionResult Delete(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           var clientSet =  _unit.ReposClient.GetById((int)id);
           if (clientSet == null)
           {
               return HttpNotFound();
           }
           return View(clientSet);
       }

       // POST: Client/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       [Authorize(Roles = "admin")]
       public ActionResult DeleteConfirmed(int id)
       {
           try
           {
               var clientSet = _unit.ReposClient.GetById(id);
               _unit.ReposClient.Delete(clientSet);
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
