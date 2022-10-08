using HoLGame.DATA.Infrastructure;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA
{
    public class SuitRepository : RepositoryBase<Suit, HoLGameContext>, ISuitRepository
    {
        public SuitRepository(IDbFactory<HoLGameContext> dbFactory) : base(dbFactory)
        {

        }
    }

    public interface ISuitRepository : IRepository<Suit>
    {

    }
}
