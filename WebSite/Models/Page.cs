using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class Page
    {
        public int Order { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Parameters { get; set; }
        public virtual Page Parent { get; set; }
        public virtual ICollection<Page> Child { get; set; }
        public IDictionary<string, string> GetParameters()
        {
            return Parameters
                .Split('&')
                .Where(pair => !string.IsNullOrEmpty(pair))
                .Select(pair => pair.Split('='))
                .ToDictionary(pair => pair[0], _ => _[1]);
        }
        public Microsoft.AspNetCore.Routing.RouteValueDictionary GetRouteData()
        {
            var routeData = new Microsoft.AspNetCore.Routing.RouteValueDictionary(GetParameters());
            routeData.Add("controller", Controller);
            routeData.Add("action", Action);
            return routeData;
        }
    }
}
