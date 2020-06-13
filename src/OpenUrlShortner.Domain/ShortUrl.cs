using System;

namespace OpenUrlShortner.Domain
{
    public class ShortUrl
    {
        public string Id { get; set; }

        public string OriginalUrl { get; set; }

        public string Url { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public ShortUrl()
        {
            Id = Guid.NewGuid().ToString();
            Created = DateTime.UtcNow;
            CreatedBy = "System";
        }
    }
}
