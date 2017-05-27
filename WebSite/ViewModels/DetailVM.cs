using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.ViewModels
{
    public class DetailVM
    {
        public DetailVM(Page model, ContentInfoExpr content)
        {
            Current = model;
            Content = content.Content;
            Descriptions = new[] {
                new ContentCard() { Title = "課題文", Content = content.Subject },
                new ContentCard() { Title = "感想", Content = content.Comment }
            };
        }
        public DetailVM(Page model, ContentTakao content)
        {
            Current = model;
            Content = content.Content;
            Descriptions = new[] {
                new ContentCard() { Title = "説明", Content = content.Comment }
            };
        }

        public Page Current { get; }
        public string Content { get; }
        public ICollection<ContentCard> Descriptions { get; }
        public bool HasPreviousItem { get; set; }
        public bool HasNextItem { get; set; }
        public int PrevIndex { get; set; }
        public int NextIndex{ get; set; }
    public string CurrentArticle { get; set; }
    }
}
