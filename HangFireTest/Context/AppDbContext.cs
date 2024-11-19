using Microsoft.EntityFrameworkCore;

namespace HangFireTest.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
