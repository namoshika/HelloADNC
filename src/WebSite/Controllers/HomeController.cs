using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public HomeController(Data.AppDbContext db) { _db = db; }
        Data.AppDbContext _db;

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var rootPage = await _db.Page.FindAsync("root");
            var aboutPage = await _db.Page.FindAsync("root/about");
            var pin = await _db.RootPin.Include(_ => _.Title).Include(_ => _.Page).OrderBy(_ => _.Id).ToListAsync();

            return View(new RootVM(this, rootPage, aboutPage, pin));
        }
        [Route("about/")]
        public async Task<IActionResult> About()
        {
            var pageModel = await _db.Page.FindAsync("root/about");
            var cardModel = await _db.ContentCard.Where(_ => _.Owner == pageModel).OrderBy(_ => _.Order).ToListAsync();
            return View("CardList1", new ListVM<ContentCard>(pageModel, cardModel));
        }
        [Route("gallery/")]
        public async Task<IActionResult> Gallery()
        {
            var pageModel = await _db.Page.FindAsync("root/gallery");
            var itemModels = await _db.Page.Where(_ => _.Parent == pageModel).OrderBy(_ => _.Order).ToListAsync();
            return View("PageList1", new ListVM<Page>(pageModel, itemModels));
        }
        [Route("product/")]
        public async Task<IActionResult> Product()
        {
            var pageModel = await _db.Page.FindAsync("root/product");
            var itemModels = await _db.Page.Where(_ => _.Parent == pageModel).OrderBy(_ => _.Order).ToListAsync();
            return View("PageList1", new ListVM<Page>(pageModel, itemModels));
        }
    }
}
