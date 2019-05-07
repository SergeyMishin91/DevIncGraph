using DevIncGraph.Models;
using Microsoft.EntityFrameworkCore;

namespace DevIncGraph.Data
{
    public class DevIncGraphContext : DbContext
    {
        public DevIncGraphContext(DbContextOptions<DevIncGraphContext> options)
            : base(options)
        {
        }

        public DbSet<Point> ContextPoints { get; set; }
        public DbSet<UserData> ContextUserDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>()
                .HasMany(p => p.Points);
        }
    }
}
