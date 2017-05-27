using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.ViewModels
{
    public class GroupVM<TContent>
    {
        public GroupVM(string title, ICollection<TContent> contents)
        {
            Title = title;
            Contents = contents;
        }
        public string Title { get; }
        public ICollection<TContent> Contents { get; }
    }
}
