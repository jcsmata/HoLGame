using HoLGame.DATA.Infrastructure;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA.Repository
{
    public class GamePlayerRepository : RepositoryBase<GamePlayer, HoLGameContext>, IGamePlayerRepository
    {
        public GamePlayerRepository(IDbFactory<HoLGameContext> dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IGamePlayerRepository : IRepository<GamePlayer>
    {
    }
}
