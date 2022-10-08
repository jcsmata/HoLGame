using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.MODELS
{
    public class Deck
    {
        public int Id { get; set; }

        public int SuitId { get; set; }
        public Suit Suit { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
