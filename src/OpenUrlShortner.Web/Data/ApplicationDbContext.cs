using Microsoft.EntityFrameworkCore;
using OpenUrlShortner.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenUrlShortner.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ShortUrl> Urls { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
