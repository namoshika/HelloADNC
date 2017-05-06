using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Models;
using WebSite.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSite.Controllers
{
    using Models;

    public class LocatorViewComponent : ViewComponent
    {
        public LocatorViewComponent(Data.AppDbContext db) { _db = db; }
        Data.AppDbContext _db;

        public IViewComponentResult Invoke(string viewName)
        {
            var current = _db.Page
                .Where(pg =>
                    pg.Controller == (string)RouteData.Values["controller"] &&
                    pg.Action == (string)RouteData.Values["Action"])
                .AsEnumerable()
                .Where(pg =>
                {
                    var rd = pg.GetRouteData();
                    return
                        rd.Count == RouteData.Values.Count &&
                        Enumerable.Zip(rd.OrderBy(pair => pair.Key),
                            RouteData.Values.OrderBy(pair => pair.Key), (a, b) => a.Equals(b)).All(res => res);
                })
                .First();
            var parts = current.Id.Split('/').ToArray();
            var parentIds = parts.Select((s, i) => string.Join("/", parts, 0, i + 1)).ToList();
            var parentPgs = _db.Page
                .Where(_ => parentIds.Contains(_.Id)).OrderBy(_ => _.Id.Length).ToList();

            //return View(viewName, parentPgs);
            return View(viewName, parentPgs);
        }
    }
}
