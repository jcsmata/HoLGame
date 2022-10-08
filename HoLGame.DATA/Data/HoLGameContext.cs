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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    
            modelBuilder.Entity<Suit>().ToTable("suite");
        }
    }
}
