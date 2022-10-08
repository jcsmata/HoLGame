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

        public void SaveGame()
        {
            unitOfWork.Commit();
        }
    }
}
