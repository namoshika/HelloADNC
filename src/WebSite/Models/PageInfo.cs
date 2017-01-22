using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Routing;

namespace WebSite.Models
{
    public class PageInfo
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
    public class PagePathHelper
    {
        public PagePathHelper(PageInfo[][] breadcrumb)
        { _breadcrumb = breadcrumb; }
        PageInfo[][] _breadcrumb;

        public PageInfo[] GetCurrent(RouteData routeData)
        {
            var model = _breadcrumb.First(pathArray =>
            {
                var current = pathArray[pathArray.Length - 1];
                var currentParams = current.Parameters;
                var requestParams = routeData.Values.ToDictionary(
                    pair => pair.Key, pair => pair.Value.ToString());
                var requestParamsLen = routeData.Values.Count(
                    pair => pair.Key != "controller" && pair.Key != "action");

                if (current.Parameters.Count != requestParamsLen)
                    return false;
                if (currentParams.Any(pair => !requestParams.Contains(pair)))
                    return false;
                return current.Controller == (string)routeData.Values["controller"]
                    && current.Action == (string)routeData.Values["action"];
            });
            return model;
        }
    }
    public static class PagePathExtensions
    {
        public static void AddPagemap(this IServiceCollection service)
        {
            service.AddSingleton(_ =>
            {
                var source = XElement.Load("pagemap.xml");
                var results = new List<PageInfo[]>();
                var nextNodes = new Stack<Work<XElement>>(new[] { new Work<XElement>(false, source) });
                var rootChain = new Stack<PageInfo>();
                while (nextNodes.Count > 0)
                {
                    var current = nextNodes.Peek();
                    if (current.IsChecked == false)
                    {
                        current.IsChecked = true;
                        rootChain.Push(new PageInfo()
                        {
                            Title = current.Value.Attribute("title").Value,
                            Controller = current.Value.Attribute("controller").Value,
                            Action = current.Value.Attribute("action").Value,
                            Parameters = current.Value.Attributes()
                                .Where(attr => attr.Name.LocalName.IndexOf("asp-route-") == 0)
                                .Select(attr => Tuple.Create(attr.Name.LocalName.Substring("asp-route-".Length), attr.Value))
                                .ToDictionary(pair => pair.Item1, pair => pair.Item2)
                        });
                        results.Add(rootChain.Reverse().ToArray());
                        foreach (var item in current.Value.Elements("page"))
                            nextNodes.Push(new Work<XElement>(false, item));
                    }
                    else
                    {
                        rootChain.Pop();
                        nextNodes.Pop();
                    }
                }
                return results.ToArray();
            });
        }
        class Work<T>
        {
            public Work(bool isChecked, T value)
            {
                IsChecked = isChecked;
                Value = value;
            }
            public bool IsChecked;
            public T Value;
        }
    }
}
