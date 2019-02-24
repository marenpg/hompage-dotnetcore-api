using GulnesApi.Data.Jokes;
using Microsoft.EntityFrameworkCore;

namespace GulnesApi.Data
{
    public class GulnesContext : DbContext
    {
        public GulnesContext(DbContextOptions options)
            :base(options)
        { }

        public DbSet<Joke> Jokes { get; set; }

    }
}
