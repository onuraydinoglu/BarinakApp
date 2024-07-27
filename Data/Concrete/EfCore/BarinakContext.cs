using Barinak.Entity;
using Microsoft.EntityFrameworkCore;

namespace Barinak.Data
{
    public class BarinakContext : DbContext
    {
        public BarinakContext(DbContextOptions<BarinakContext> options) : base(options) { }

        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<Breed> Breeds => Set<Breed>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<User> Users => Set<User>();
    }
}