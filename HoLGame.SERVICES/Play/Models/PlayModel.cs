using HoLGame.COMMONS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public class PlayModel
    {
        [Range(0,1)]
        public Enums.Choice choice { get; set; }
        public string playerName { get; set; }
        public string gameIdentifier { get; set; }

    }
}
