using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public class PlayerModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
