using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public class GamePlayerJoinModel
    {
        [Required]
        public string GameIdentifier { get; set; }
        [Required]
        public string PlayerName { get; set; }

        public int GameId { get; set; }
        public int PlayerId { get; set; }
    }
}
