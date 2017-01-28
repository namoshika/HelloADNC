using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
    using Models;

    [Route("/")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("about/")]
        public IActionResult About()
        {
            return View();
        }
        [Route("gallery/")]
        public IActionResult Gallery()
        {
            var model = new CatalogInfo<LinkInfo>()
            {
                Id = "gallery",
                Title = "Gallery",
                Summary = "授業で作成した成果物を陳列してあります。",
                Children = new[]
                {
                    new LinkInfo()
                    {
                        Id = "100720infoExpr",
                        Title = "大学演習科目課題",
                        Summary = "授業の課題で作成した成果物を陳列しています。",
                        ThumbnailUrl = "~/gallery/100720infoExpr/image/thumb.jpg",
                        Controller = "Gallery",
                        Action = "List",
                        Parameters = new Dictionary<string, string>() { { "article", "100720infoExpr" } }
                    },
                    new LinkInfo()
                    {
                        Id = "100823takao",
                        Title = "夏季休暇課題",
                        Summary = "夏の高尾山の動植物他諸々を撮って片っ端から調べてみました。",
                        ThumbnailUrl = "~/gallery/100823takao/image/thumb.jpg",
                        Controller = "Gallery",
                        Action = "List",
                        Parameters = new Dictionary<string, string>() { { "article", "100823takao" } }
                    },
                    new LinkInfo()
                    {
                        Id = "170128experiment",
                        Title = "実験場",
                        Summary = "色々試す場所",
                        ThumbnailUrl = "~/gallery/170128experiment/image/thumb.gif",
                        Controller = "Gallery",
                        Action = "List",
                        Parameters = new Dictionary<string, string>() { { "article", "170128experiment" } }
                    },
                }
            };
            return View("Catalog", model);
        }
        [Route("product/")]
        public IActionResult Product()
        {
            var model = new CatalogInfo<LinkInfo>()
            {
                Id = "product",
                Title = "Product",
                Summary = "色々、(中間)生成物を保管しています。",
                Children = new[]
                {
                    new LinkInfo()
                    {
                        Id = "snippet",
                        Title = "Snippet",
                        Summary = "このサイトを作成する際に作成したものを使いやすい形にして陳列しています。",
                        ThumbnailUrl = "~/product/snippet/image/thumb.gif",
                        Controller = "Snippet",
                        Action = "Index",
                    },
                }
            };
            return View("Catalog", model);
        }
    }
}
