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
    [Route("gallery/")]
    public class GalleryController : Controller
    {
        public GalleryController(Data.AppDbContext db) { _db = db; }
        Data.AppDbContext _db;

        [Route("{article}/")]
        public async Task<IActionResult> List(string article)
        {
            var targetPage = await _db.Page.FindAsync($"root/gallery/{article}");
            if (targetPage == null)
                return NotFound();

            //実験場は他とデータの持ち方や表示方法が異なるため、別処理を使用する。
            var groups = new List<Group>();
            if (article == "170128experiment")
            {
                var fileLinks = System.IO.Directory.EnumerateFiles("./wwwroot/gallery/170128experiment")
                    .Select(filePath =>
                        new ContentCard()
                        {
                            Type = CardType.Text,
                            Title = System.IO.Path.GetFileName(filePath),
                            Content = Url.Content("~" + filePath.Substring("./wwwroot".Length))
                        })
                    .ToList();
                var groupModels = new List<GroupVM<ContentCard>>() { new GroupVM<ContentCard>(null, fileLinks) };
                return View("CardList_exp", new ListVM<GroupVM<ContentCard>>(targetPage, groupModels));
            }
            else
            {
                var groupModels = await _db.Group
                    .Where(grp => grp.UseBy == targetPage)
                    .Include(_ => _.Page)
                    .OrderBy(grp => grp.Id)
                    .Select(_ => new GroupVM<Page>(_.Title, _.Page.OrderBy(pg => pg.Order).ToList()))
                    .ToListAsync();
                return View("PageList2", new ListVM<GroupVM<Page>>(targetPage, groupModels));
            }
        }
        [Route("{article}/{id}")]
        public async Task<IActionResult> Detail(string article, int id)
        {
            Page pageModel;
            DetailVM vm;
            //pageModel, vmを生成
            switch (article)
            {
                case "100720infoExpr":
                    var infoExprModel = await _db.ContentInfoExpr.Include(_ => _.Owner)
                        .FirstOrDefaultAsync(_ => _.Owner.Id == string.Format("root/gallery/{0}/{1}", article, id));
                    if (infoExprModel == null)
                        return NotFound();

                    pageModel = infoExprModel.Owner;
                    vm = new DetailVM(pageModel, infoExprModel);
                    break;
                case "100823takao":
                    var takaoModel = await _db.ContentTakao.Include(_ => _.Owner)
                        .FirstOrDefaultAsync(_ => _.Owner.Id == string.Format("root/gallery/{0}/{1}", article, id));
                    if (takaoModel == null)
                        return NotFound();

                    pageModel = takaoModel.Owner;
                    vm = new DetailVM(pageModel, takaoModel);
                    break;
                default:
                    return NotFound();
            }
            //vmの残り項目を埋める
            var len = await _db.Page.Where(_ => _.Parent == pageModel.Parent).CountAsync();
            vm.HasPreviousItem = id > 0;
            vm.HasNextItem = id < len - 1;
            vm.PrevIndex = id - 1;
            vm.NextIndex = id + 1;
            vm.CurrentArticle = article;

            return View(vm);
        }
    }
}
