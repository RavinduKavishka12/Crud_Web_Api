using Microsoft.EntityFrameworkCore;
using simpleWebApi.Models;

namespace simpleWebApi.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
      
    }
}
