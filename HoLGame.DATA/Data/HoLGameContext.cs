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
        public DbSet<GamePlayer> GamePlayers { get; set; }
        public DbSet<Play> Plays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            //TODO: Move to configuration files per entity
            modelBuilder.Entity<Suit>().ToTable("Suite");
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<Deck>().ToTable("Deck");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<GamePlayer>()
                .Property(p => p.isPlaying).HasDefaultValue(true);

            modelBuilder.Entity<GamePlayer>().ToTable("GamePlayer")
                .HasKey(g => new { g.GameId, g.PlayerId });

            modelBuilder.Entity<Play>().ToTable("Play")
                .HasKey(p => p.Id);

            modelBuilder.Entity<GamePlayer>().Navigation(g => g.Player).AutoInclude();
            modelBuilder.Entity<GamePlayer>().Navigation(g => g.Game).AutoInclude();

            modelBuilder.Entity<Deck>().Navigation(d => d.Card).AutoInclude();
            modelBuilder.Entity<Deck>().Navigation(d => d.Suit).AutoInclude();

            modelBuilder.Entity<Play>().Navigation(d => d.Deck).AutoInclude();
            modelBuilder.Entity<Play>().Navigation(d => d.Game).AutoInclude();
            modelBuilder.Entity<Play>().Navigation(d => d.Player).AutoInclude();



        }
    }
}
