using Microsoft.EntityFrameworkCore;
using petro_home_back.Model.Test;

namespace petro_home_back.Service
{
    public class MsSQLDbContext : DbContext
    {
        public MsSQLDbContext(DbContextOptions<MsSQLDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = new TestModelMap(modelBuilder.Entity<TestModel>());
            modelBuilder.Entity<TestModel>().ToTable("test");
        }
    }
}
