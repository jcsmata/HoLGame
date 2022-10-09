using HoLGame.MODELS;
using Microsoft.EntityFrameworkCore;
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
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if(!context.Suites.Any())
            {
                var suites = new Suit[]
                {
                    new Suit { SuitName = "Spades", SuitSymbol = "U+2664" },
                    new Suit { SuitName = "Hearts", SuitSymbol = "U+2661" },
                    new Suit { SuitName = "Diamonds", SuitSymbol = "U+2662" },
                    new Suit { SuitName = "Clubs", SuitSymbol = "U+2667" },
                };

                foreach(Suit s in suites)
                {
                    context.Suites.Add(s);
                }

                context.SaveChanges();                
            }

            if(!context.Cards.Any())
            {
                var cards = new Card[]
                {
                    new Card { Name = "2", Value = 2},
                    new Card { Name = "3", Value = 3},
                    new Card { Name = "4", Value = 4},
                    new Card { Name = "5", Value = 5},
                    new Card { Name = "6", Value = 6},
                    new Card { Name = "7", Value = 7},
                    new Card { Name = "8", Value = 8},
                    new Card { Name = "9", Value = 9},
                    new Card { Name = "10", Value = 10},
                    new Card { Name = "J", Value = 11},
                    new Card { Name = "Q", Value = 12},
                    new Card { Name = "K", Value = 13},
                    new Card { Name = "A", Value = 14},
                };

                foreach(Card c in cards)
                {
                    context.Cards.Add(c);
                }

                context.SaveChanges();
            }

            if(!context.Decks.Any())
            {
                foreach(Suit s in context.Suites)
                    foreach(Card c in context.Cards)
                        context.Decks.Add(new Deck { CardId = c.Id, SuitId = s.Id });
                    

                context.SaveChanges();
            }

        }
    }
}
