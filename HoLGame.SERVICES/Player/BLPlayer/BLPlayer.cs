using AutoMapper;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IBLPlayer
    {
        string CreatePlayer(PlayerModel playerModel);
    }

    public class BLPlayer : IBLPlayer
    {
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;

        public BLPlayer(IPlayerService playerService, IMapper mapper)
        {
            this.playerService = playerService;
            this.mapper = mapper;
        }

        public string CreatePlayer(PlayerModel playerModel)
        {
            var player = mapper.Map<Player>(playerModel);

            playerService.CreatePlayer(player);
            playerService.SavePlayer();

            return player.Name;

        }
    }

}
