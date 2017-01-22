using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebSite.Controllers
{
    using Models;

    public class PagePathViewComponent : ViewComponent
    {
        public PagePathViewComponent(PagePathHelper pathManager)
        { _pathManager = pathManager; }
        PagePathHelper _pathManager;
        public IViewComponentResult Invoke(string viewName)
        {
            var model = _pathManager.GetCurrent(RouteData);
            return View(viewName, model);
        }
    }
}
