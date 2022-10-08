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
        Task<string> CreateGame(GameModel model);
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

        public Task<string> CreateGame(GameModel model)
        {
            Guid g = Guid.NewGuid();

            var game = mapper.Map<Game>(model);
            game.Identifier = g.ToString();

            gameService.CreateGame(game);
            gameService.SaveGame();

            return Task.FromResult(game.Identifier);
        }
    }
}
