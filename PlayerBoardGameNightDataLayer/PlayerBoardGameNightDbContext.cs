using DomainCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerBoardGameNightDataLayer
{
    public class PlayerBoardGameNightDbContext : DbContext
    {
        public PlayerBoardGameNightDbContext(DbContextOptions<PlayerBoardGameNightDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>().HasKey(player => player.Email);
        }
        public DbSet<Player> Player { get; set; }
    }
}
