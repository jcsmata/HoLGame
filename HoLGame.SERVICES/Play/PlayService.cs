using HoLGame.DATA;
using HoLGame.DATA.Infrastructure;
using HoLGame.DATA.Repository;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IPlayService
    {
        void CreatePlay(Play play);
        void SavePlay();
        void UpdatePlay(Play play);
        IEnumerable<Play> GetPlaysByGameIdentifier(string gameIdentifier);
    }
    public class PlayService : IPlayService
    {
        private readonly IPlayRepository playRepository;
        private readonly IUnitOfWork<HoLGameContext> unitOfWork;
        
        public PlayService(IPlayRepository playRepository, IUnitOfWork<HoLGameContext> unitOfWork)
        {
            this.playRepository = playRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreatePlay(Play play)
        {
            playRepository.Add(play);
        }

        public void SavePlay()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Play> GetPlaysByGameIdentifier(string gameIdentifier)
        {
            return playRepository.GetMany(p => p.Game.Identifier == gameIdentifier);
        }

        public void UpdatePlay(Play play)
        {
            playRepository.Update(play);
        }




    }
}
