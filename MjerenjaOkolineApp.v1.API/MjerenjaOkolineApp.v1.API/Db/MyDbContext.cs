using Microsoft.EntityFrameworkCore;
using MjerenjaOkolineApp.v1.API.Models;

namespace MjerenjaOkolineApp.v1.API.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<MjerenjeOkoline> MjerenjaOkoline => Set<MjerenjeOkoline>();

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
    }
}
