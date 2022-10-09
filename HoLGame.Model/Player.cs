using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.MODELS
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public virtual ICollection<GamePlayer> GamePlayers { get; set; }

    }
}
