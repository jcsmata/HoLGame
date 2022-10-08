using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    
    public class GameModel
    {
        [Required]
        public string Name { get; set; }
        [Range(1, 4)]
        public int NumberPlayers { get; set; }
    }
}
