using HoLGame.DATA.Infrastructure;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA
{
    public class GameRepository : RepositoryBase<Game, HoLGameContext>, IGameRepository
    {
        public GameRepository(IDbFactory<HoLGameContext> dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IGameRepository : IRepository<Game>
    {
    }
}
