using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatcherModel;
using WatcherModel.Repository;
using WebSales.Models;

namespace WebSales.Controllers
{
     [Authorize]
    public class OrderController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork(new ModelContainer());
        private IRepository<Order> repo;

        public OrderController()
        {
            repo=_unit.ReposOrder;
        }

        public ActionResult Index(FilterDataModels filterPost, int page=1)
        {
            FilterDataModels filters=new FilterDataModels();
            filters.Orders = repo.SearchFor(x=>x.Date>=filterPost.DateStart&&x.Date<=filterPost.DateFinish);

            if (filterPost.FilterClient != null)
            {
                filters.Orders = filters.Orders.Where(e => e.IdClient == filterPost.FilterClient);
            }
            if (filterPost.FilterGoods != null)
            {
                filters.Orders = filters.Orders.Where(e => e.IdGoods == filterPost.FilterGoods);
            }
            if (filterPost.FilterManager != null)
            {
                filters.Orders = filters.Orders.Where(e => e.IdManager == filterPost.FilterManager);
            }
            if (filterPost.FilterNameFile != null)
            {
                filters.Orders = filters.Orders.Where(e => e.IdFile == filterPost.FilterNameFile);
            }

            if (!String.IsNullOrEmpty(filterPost.searchString))
            {
                filters.Orders = filters.Orders.Where(s => s.Manager.FirstName.Contains(filterPost.searchString)
                                       || s.Goods.NameGoods.Contains(filterPost.searchString)
                                       || s.Client.FirstName.Contains(filterPost.searchString));
            }

            ViewBag.FilterClient = new SelectList(_unit.ReposClient.GetAll(), "Id", "FirstName");
            ViewBag.FilterGoods = new SelectList(_unit.ReposGoods.GetAll(), "Id", "NameGoods");
            ViewBag.FilterManager = new SelectList(_unit.ReposManager.GetAll(), "Id", "FirstName");
            ViewBag.FilterNameFile = new SelectList(_unit.ReposNameFile.GetAll(), "Id", "Name");
          
            int pageSize = 7; // количество объектов на страницу
            filters.PageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = filters.Orders.Count() };
            filters.Orders=filters.Orders.OrderBy(x=>x.Date).Skip((page - 1) * pageSize).Take(pageSize);
            return View(filters);
        }

        // GET: order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var orderSet = repo.GetById((int)id);
                if (orderSet == null)
                {
                    return HttpNotFound();
                }
                return View(orderSet);
            }
        }

        // GET: order/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(_unit.ReposClient.GetAll(), "Id", "FirstName");
            ViewBag.IdGoods = new SelectList(_unit.ReposGoods.GetAll(), "Id", "NameGoods");
            ViewBag.IdManager = new SelectList(_unit.ReposManager.GetAll(), "Id", "FirstName");
            ViewBag.IdFile = new SelectList(_unit.ReposNameFile.GetAll(), "Id", "Name");
            return View();
        }

        // POST: order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,IdManager,IdClient,IdGoods,Cost,Date,IdFile")] Order orderSet)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(orderSet);
                _unit.Save();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(_unit.ReposClient.GetAll(), "Id", "FirstName", orderSet.IdClient);
            ViewBag.IdGoods = new SelectList(_unit.ReposGoods.GetAll(), "Id", "NameGoods", orderSet.IdGoods);
            ViewBag.IdManager = new SelectList(_unit.ReposManager.GetAll(), "Id", "FirstName", orderSet.IdManager);
            ViewBag.IdFile = new SelectList(_unit.ReposNameFile.GetAll(), "Id", "Name", orderSet.IdFile);
            return View(orderSet);
        }

        // GET: order/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderSet = repo.GetById((int)id);
            if (orderSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(_unit.ReposClient.GetAll(), "Id", "FirstName", orderSet.IdClient);
            ViewBag.IdGoods = new SelectList(_unit.ReposGoods.GetAll(), "Id", "NameGoods", orderSet.IdGoods);
            ViewBag.IdManager = new SelectList(_unit.ReposManager.GetAll(), "Id", "FirstName", orderSet.IdManager);
            ViewBag.IdFile = new SelectList(_unit.ReposNameFile.GetAll(), "Id", "Name", orderSet.IdFile);
            return View(orderSet);
        }

        // POST: order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,IdManager,IdClient,IdGoods,Cost,Date,IdFile")] Order orderSet)
        {
            if (ModelState.IsValid)
            {
                repo.Update(orderSet);
                _unit.Save();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(_unit.ReposClient.GetAll(), "Id", "FirstName", orderSet.IdClient);
            ViewBag.IdGoods = new SelectList(_unit.ReposGoods.GetAll(), "Id", "NameGoods", orderSet.IdGoods);
            ViewBag.IdManager = new SelectList(_unit.ReposManager.GetAll(), "Id", "FirstName", orderSet.IdManager);
            ViewBag.IdFile = new SelectList(_unit.ReposNameFile.GetAll(), "Id", "Name", orderSet.IdFile);
            return View(orderSet);
        }

        // GET: order/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderSet = repo.GetById((int)id);
            if (orderSet == null)
            {
                return HttpNotFound();
            }
            return View(orderSet);
        }

        // POST: order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            var orderSet = repo.GetById((int)id);
            repo.Delete(orderSet);
            _unit.Save();
            return RedirectToAction("Index");
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
