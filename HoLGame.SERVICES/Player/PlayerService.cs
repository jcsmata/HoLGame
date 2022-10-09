using HoLGame.DATA;
using HoLGame.DATA.Infrastructure;
using HoLGame.DATA.Repository;
using HoLGame.MODELS;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IPlayerService
    {
        void CreatePlayer(Player player);
        Player GetPlayerByName(string playerName);
        void SavePlayer();
    }
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;
        private readonly IUnitOfWork<HoLGameContext> unitOfWork;

        public PlayerService(IPlayerRepository playerRepository, IUnitOfWork<HoLGameContext> unitOfWork)
        {
            this.playerRepository = playerRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreatePlayer(Player player)
        {
            playerRepository.Add(player);
        }

        public Player GetPlayerByName(string playerName)
        {
            return playerRepository.Get(p => p.Name == playerName);
        }

        public void SavePlayer()
        {
            unitOfWork.Commit();
        }
    }
}
