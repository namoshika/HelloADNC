using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class GroupInfo<T>
    {
        public string Title { get; set; }
        public T[] Children { get; set; }
    }
}
