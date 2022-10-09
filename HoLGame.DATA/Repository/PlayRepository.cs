using HoLGame.DATA.Infrastructure;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA.Repository
{
    public class PlayRepository : RepositoryBase<Play, HoLGameContext>, IPlayRepository
    {
        public PlayRepository(IDbFactory<HoLGameContext> dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IPlayRepository : IRepository<Play>
    {

    }
}
