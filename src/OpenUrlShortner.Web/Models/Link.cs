using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenUrlShortner.Web.Models
{
    public class Link
    {
        public string Href { get; set; }

        public string Rel { get; set; }
        
        public string Method { get; set; }

        public Link(string href, string rel, string method)
        {
            Href = href ?? throw new ArgumentNullException(nameof(href));
            Rel = rel ?? throw new ArgumentNullException(nameof(rel));
            Method = method ?? throw new ArgumentNullException(nameof(method));
        }

        public Link()
        {
        }
    }
}
