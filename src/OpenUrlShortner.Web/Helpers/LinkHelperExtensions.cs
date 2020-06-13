using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenUrlShortner.Web.Helpers
{
    public static class LinkHelperExtensions
    {
        public static LinkHelper<T> WithLink<T>(this LinkHelper<T> link, string href, string rel, string method)
            where T : class
        {
            link.AddLink(href, rel, method);
            return link;
        }

        public static LinkHelper<T> WithLink<T>(this LinkHelper<T> link, string href, string rel, HttpMethod method)
           where T : class
        {
            link.AddLink(href, rel, method.Method);
            return link;
        }
    }
}
