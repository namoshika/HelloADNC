using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class CatalogInfo : ContentInfo
    {
        public IEnumerable<LinkInfo> Children { get; set; }
    }
    public class LinkInfo : ContentInfo
    {
        public string ThumbnailUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public IDictionary<string, string> Parameters { get; set; }
    }
}
