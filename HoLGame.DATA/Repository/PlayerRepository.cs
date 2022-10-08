using HoLGame.DATA.Infrastructure;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA.Repository
{
    public class PlayerRepository : RepositoryBase<Player, HoLGameContext>, IPlayerRepository
    {
        public PlayerRepository(IDbFactory<HoLGameContext> dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IPlayerRepository : IRepository<Player>
    {
    }
}
