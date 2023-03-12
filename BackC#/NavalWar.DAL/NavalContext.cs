using Microsoft.EntityFrameworkCore;
using NavalWar.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalWar.DAL
{
    public class NavalContext : DbContext
    {

        public NavalContext(DbContextOptions<NavalContext> options) : base(options)
        {
        }

        public DbSet<PlayerDb> Players { get; set; }
        public DbSet<SessionDb> SessionDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerDb>().ToTable("Player");
            
            modelBuilder.Entity<SessionDb>()
            .HasOne(g => g.Player1)
            .WithOne()
            .HasForeignKey<SessionDb>(g => g.Player1Id)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SessionDb>()
            .HasOne(g => g.Player2)
            .WithOne()
            .HasForeignKey<SessionDb>(g => g.Player2Id)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
