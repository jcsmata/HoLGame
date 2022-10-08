using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA
{
    public static class DbInitializer
    {
        public static void Initialize(HoLGameContext context)
        {
            context.Database.EnsureCreated();

            if(context.Suites.Any())
            {
                return;
            }

            var suites = new Suit[]
            {
                new Suit { SuitName = "Spades", SuitSymbol = "U+2664" },
                new Suit { SuitName = "Hearts", SuitSymbol = "U+2661" },
                new Suit { SuitName = "Diamongs", SuitSymbol = "U+2662" },
                new Suit { SuitName = "Clubs", SuitSymbol = "U+2667" },
            };

            foreach(Suit s in suites)
            {
                context.Suites.Add(s);
            }

            context.SaveChanges();
        }
    }
}
