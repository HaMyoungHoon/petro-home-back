using Microsoft.EntityFrameworkCore;
using petro_home_back.Model.Base;
using petro_home_back.Model.Homepage;

namespace petro_home_back.Service
{
    public class HomepageDbContext : DbContext
    {
        public HomepageDbContext(DbContextOptions<HomepageDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            _ = new UserModelMap(modelBuilder.Entity<UserModel>().ToTable("admin_user"));
            _ = new HistoryModelMap(modelBuilder.Entity<HistoryModel>().ToTable("history"));
            _ = new PopModelMap(modelBuilder.Entity<PopModel>().ToTable("pop"));
        }
    }
}
