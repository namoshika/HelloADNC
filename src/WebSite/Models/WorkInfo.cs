using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Models
{
    public class WorkInfo : ContentInfo
    {
        public string Content { get; set; }
        public CardInfo[] Descriptions { get; set; }
    }
    public class CardInfo
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
