using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.MODELS
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public int NumberPlayers { get; set; }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }
    }
}
