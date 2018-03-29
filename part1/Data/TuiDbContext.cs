using Microsoft.EntityFrameworkCore;

namespace CodeInsider.Tui.Assessment.Data
{
    public class TuiDbContext : DbContext
    {
        private const string ConnectionString = "Data Source=CodeInsider.Tui.Assessment.db";
        public DbSet<Flight> Flights {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }
}