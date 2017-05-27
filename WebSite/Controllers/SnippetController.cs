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
    [Route("product/snippet/")]
    public class SnippetController : Controller
    {
        public SnippetController(Data.AppDbContext db) { _db = db; }
        Data.AppDbContext _db;

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var pageModel = await _db.Page.FindAsync("root/product/snippet");
            var cardModel = await _db.ContentCard.Where(_ => _.Owner == pageModel).ToListAsync();
            return View("CardList2", new ListVM<ContentCard>(pageModel, cardModel));
        }
    }
}
