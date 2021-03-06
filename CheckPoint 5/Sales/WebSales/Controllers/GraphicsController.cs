﻿using System.Linq;
using System.Web.Mvc;
using WatcherModel;
using WatcherModel.Repository;
using WebSales.Models;

namespace WebSales.Controllers
{
    [Authorize]
    public class GraphicsController : Controller
    {
        private UnitOfWork _unit = new UnitOfWork(new ModelContainer());
        // GET: Graphics
        public ActionResult Index()
        {
            ViewBag.FilterManager = new SelectList(_unit.ReposManager.GetAll().OrderBy(x => x.SecondName), "Id", "SecondName");
            return View(new FilterModels());
        }
               
        public JsonResult JsonSearch([Bind(Include = "FilterManager,DateStart,DateFinish")] FilterModels filter)//,DateTime dateStart,DateTime DateTimeFinish)
        {
            var idManger = filter.FilterManager;
            var query = from tt in _unit.ReposOrder.GetAll()
                        where tt.Date >= filter.DateStart && tt.Date <= filter.DateFinish
                        select tt;
            if (idManger != null)
            {
                query = query.Where(x => x.IdManager == idManger);
            }
            var zz = (from tt in query
                      let date = tt.Date.Day + "." + tt.Date.Month + "." + tt.Date.Year
                      group tt by date into g
                      select new ChartGoodsDate
                      {
                          DateStr = g.Key,
                          CountGoods = g.Count()
                      }).ToList<ChartGoodsDate>().OrderBy(x => x.Date);
            return Json(zz);//, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Pie()
        {
            ViewBag.TotalCostOrSales = new SelectList(new[] { "Total cost", "Total sales" });
            return View(new FilterModels());
        }

        public JsonResult JsonPie(string totalCostOrSales, FilterModels filter)//[Bind(Include = "DateStart,DateFinish")] FilterModels filter,int TotalCostOrSales
        {
            var zz = (from tt in _unit.ReposOrder.GetAll()
                      where tt.Date >= filter.DateStart && tt.Date <= filter.DateFinish
                      group tt by tt.Manager into g
                      select new ChartDataPie(totalCostOrSales,g.Sum(x=>x.Cost),g.Count())
                      {
                          LastNameManager = g.Key.SecondName
                      }).ToList<ChartDataPie>();
           return Json(zz, JsonRequestBehavior.AllowGet);
        }
    }
}