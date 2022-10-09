using HoLGame.COMMONS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.MODELS
{
    public class Play
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int? PlayerId { get; set; }
        public int DeckId { get; set; }
        public Enums.Choice? PlayerChoice { get; set; }
        public Enums.Result? PlayResult { get; set; }


        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
        public virtual Deck Deck { get; set; }


    }
}
