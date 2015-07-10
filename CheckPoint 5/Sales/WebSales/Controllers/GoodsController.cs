using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WatcherModel;
using WatcherModel.Repository;

namespace WebSales.Controllers
{
    [Authorize]
    public class GoodsController : Controller
    {        
         // GET: Goods
        private UnitOfWork _unit = new UnitOfWork(new ModelContainer());
        private IRepository<Goods> repo;

        public GoodsController()
        {
            repo=_unit.ReposGoods;
        }

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        [HttpPost]
        public ActionResult SearchGoods(string name)
        {
            var goods = repo.SearchFor(a => a.NameGoods.Contains(name)).ToList();
            if (goods.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(goods);
        }
        // GET: Goods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var goodsSet = repo.GetById((int)id);
                if (goodsSet == null)
                {
                    return HttpNotFound();
                }
                return View(goodsSet);
            }
        }

        // GET: Goods/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,FirstName,SecondName")] Goods goodsSet)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(goodsSet);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View(goodsSet);
        }

        // GET: Goods/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var goodsSet = repo.GetById((int)id);
            if (goodsSet == null)
            {
                return HttpNotFound();
            }
            return View(goodsSet);
        }

        // POST: Goods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,NameGoods")] Goods goodsSet)
        {
            if (ModelState.IsValid)
            {
                repo.Update(goodsSet);
                _unit.Save();
                return RedirectToAction("Index");
            }
            return View(goodsSet);
        }

        // GET: Goods/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var goodsSet = repo.GetById((int)id);
            if (goodsSet == null)
            {
                return HttpNotFound();
            }
            return View(goodsSet);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var goodsSet = repo.GetById((int)id);
                repo.Delete(goodsSet);
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
