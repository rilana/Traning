using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WatcherModel;
using WatcherModel.Repository;
using WebSales.Models;

namespace WebSales.Controllers
{
    public class ReportsController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork(new ModelContainer());
        private IRepository<Order> repo;
        // GET: Reports
        public ActionResult Index()
        {
            ViewBag.FilterManager = new SelectList(_unit.ReposManager.GetAll(), "Id", "FirstName");             
            return View();
        }

        [HttpPost]
        public ActionResult Report(FilterModels filter)
        {
            var query = from tt in _unit.ReposOrder.GetAll()
                        where tt.Date >= filter.DateStart && tt.Date <= filter.DateFinish
                        select tt;
            ReportManagerModels reportManager;
            if (filter.FilterManager!=null)
            {
               reportManager=(from tt in query.Where(x=>x.IdManager == filter.FilterManager)
                         group tt by tt.Manager into g
                         select new ReportManagerModels()
                         {
                             NameManager = g.Key.SecondName,
                             TotalCost = g.Sum(x => x.Cost),
                             TotalSales = g.Count()
                         }).FirstOrDefault();
            }
            else if (filter.FilterGoods != null)
            {
                reportManager = (from tt in query.Where(x => x.IdGoods == filter.FilterGoods)
                                 group tt by tt.Goods into g
                                 select new ReportManagerModels()
                                 {
                                     NameGoods = g.Key.NameGoods,
                                     TotalCost = g.Sum(x => x.Cost),
                                     TotalSales = g.Count()
                                 }).FirstOrDefault();
            }
            else
            {
                reportManager = new ReportManagerModels()
                {
                    NameManager = "All",
                    TotalCost = query.Sum(x => x.Cost),
                    TotalSales = query.Count()
                };
            }            
            return PartialView(reportManager);
        }

        public ActionResult Goods()
        {
            ViewBag.FilterGoods = new SelectList(_unit.ReposGoods.GetAll(), "Id", "NameGoods");
            return View();
        }
    }
}