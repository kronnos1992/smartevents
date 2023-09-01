using gesteventos.Models;
using Microsoft.EntityFrameworkCore;

namespace gesteventos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
    }
}