using OpenUrlShortner.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenUrlShortner.Web.Helpers
{
    //based on article http://www.macoratti.net/19/05/net_hateoas1.htm
    public class LinkHelper<T> where T : class
    {
        public T Value { get; set; }

        public List<Link> Links { get; set; }

        public LinkHelper()
        {
            Links = new List<Link>();
        }

        public LinkHelper(T item) : this()
        {
            Value = item;
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }

        public void AddLink(string href, string rel, string method)
        {
            Links.Add(new Link(href, rel, method));
        }

        internal static LinkHelper<T> Create(T item)
        {
            return new LinkHelper<T>(item);
        }
    }
}
