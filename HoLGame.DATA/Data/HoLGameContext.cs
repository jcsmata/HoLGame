using HoLGame.MODELS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA
{
    public class HoLGameContext : DbContext
    {
        public HoLGameContext()
        {

        }
        public HoLGameContext(DbContextOptions<HoLGameContext> options) : base(options)
        {
        }

        public DbSet<Suit> Suites { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            //TODO: Move to configuration files per entity
            modelBuilder.Entity<Suit>().ToTable("suite");
            modelBuilder.Entity<Card>().ToTable("card");
            modelBuilder.Entity<Deck>().ToTable("deck");
            modelBuilder.Entity<Game>().ToTable("game");
            modelBuilder.Entity<Player>().ToTable("player");


        }
    }
}
