using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.MODELS
{
    public class GamePlayer
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
        public bool isPlaying { get; set; }
    }
}
