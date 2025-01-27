using Microsoft.EntityFrameworkCore;

namespace RazorPagesGPFC.Models
{
    public class GPFCContext : DbContext
    {
        public GPFCContext(DbContextOptions<GPFCContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; } //Add Matches
    }
}