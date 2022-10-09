using HoLGame.DATA;
using HoLGame.DATA.Infrastructure;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IGameService
    {
        void CreateGame(Game game);
        int? GetMaxNumberOfPlayersInGameByGameIdentifier(string gameIdentifier);
        Game GetGameByGameIdentifier(string gameIdentifier);
        void SaveGame();
    }
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;
        private readonly IUnitOfWork<HoLGameContext> unitOfWork;

        public GameService(IGameRepository gameRepository, IUnitOfWork<HoLGameContext> unitOfWork)
        {
            this.gameRepository = gameRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateGame(Game game)
        {
            gameRepository.Add(game);
        }

        public int? GetMaxNumberOfPlayersInGameByGameIdentifier(string gameIdentifier)
        {
            return gameRepository.Get(g => g.Identifier == gameIdentifier)?.NumberPlayers;
        }

        public Game GetGameByGameIdentifier(string gameIdentifier)
        {
            return gameRepository.Get(g => g.Identifier == gameIdentifier);
        }

        public void SaveGame()
        {
            unitOfWork.Commit();
        }
    }
}
