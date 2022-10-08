using AutoMapper;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IBLGame
    {
        string CreateGame(GameModel game);
    }

    public class BLGame : IBLGame
    {
        private readonly IGameService gameService;
        private readonly IMapper mapper;

        public BLGame(IGameService gameService, IMapper mapper)
        {
            this.gameService = gameService;
            this.mapper = mapper;
        }

        public string CreateGame(GameModel gameModel)
        {
            Guid g = Guid.NewGuid();

            var game = mapper.Map<Game>(gameModel);
            game.Identifier = g.ToString();

            gameService.CreateGame(game);
            gameService.SaveGame();

            return game.Identifier;
        }
    }
}
