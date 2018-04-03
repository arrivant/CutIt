using CutIt.Models;
using Microsoft.EntityFrameworkCore;

namespace CutIt
{
    public class CutItDbContext : DbContext
    {
        public CutItDbContext(DbContextOptions<CutItDbContext> options) : base(options)
        {
        }

        public DbSet<Link> Links { get; set;}
    }
}