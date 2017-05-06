using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Models;

namespace WebSite.ViewModels
{
    public class RootVM
    {
        public RootVM(Controller controller, Page root, Page about, List<Pin> pin)
        {
            Current = root;
            Pin = pin;
            Summary = string.Format(
                root.Summary,
                $"<a href=\"{controller.Url.Action(about.Action, about.Controller)}\">{Startup.SiteOwner}</a>");
        }
        public Page Current { get; }
        public List<Pin> Pin { get; }
        public string Summary { get; }
    }
}
