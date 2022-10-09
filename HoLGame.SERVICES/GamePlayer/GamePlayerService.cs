using HoLGame.DATA;
using HoLGame.DATA.Infrastructure;
using HoLGame.DATA.Repository;
using HoLGame.MODELS;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IGamePlayerService
    {
        int GetNumberOfPlayersInGame(string gameIdentifier);
        void CreateGamePlayer(GamePlayer gamePlayer);
        void SaveGamePlayer();
        IEnumerable<string> GetPlayersNameInGame(string gameIdentifier);
    }

    public class GamePlayerService : IGamePlayerService
    {
        private readonly IGamePlayerRepository gamePlayerRepository;
        private readonly IUnitOfWork<HoLGameContext> unitOfWork;

        public GamePlayerService(IGamePlayerRepository gamePlayerRepository, IUnitOfWork<HoLGameContext> unitOfWork)
        {
            this.gamePlayerRepository = gamePlayerRepository;
            this.unitOfWork = unitOfWork;
        }

        public int GetNumberOfPlayersInGame(string gameIdentifier)
        {
            return gamePlayerRepository.GetMany(x => x.Game.Identifier == gameIdentifier).Count();
        }

        public void CreateGamePlayer(GamePlayer gamePlayer)
        {
            gamePlayerRepository.Add(gamePlayer);
        }

        public void SaveGamePlayer()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<string> GetPlayersNameInGame(string gameIdentifier)
        {

            return gamePlayerRepository.GetMany(g => g.Game.Identifier == gameIdentifier).Select(g => g.Player.Name);

        }
    }
}
