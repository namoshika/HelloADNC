using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class GalleryInfo<TWork> : ContentInfo
    {
        public string Description { get; set; }
        public GroupInfo<TWork>[] Groups { get; set; }
    }
}
