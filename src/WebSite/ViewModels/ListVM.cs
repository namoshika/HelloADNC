using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.ViewModels
{
    public class ListVM<T>
    {
        public ListVM(Page current, List<T> items)
        {
            Current = current;
            Items = items;
        }
        public Page Current { get; set; }
        public List<T> Items { get; set; }
    }
}
