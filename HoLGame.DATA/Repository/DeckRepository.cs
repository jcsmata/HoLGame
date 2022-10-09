using HoLGame.DATA.Infrastructure;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.DATA
{
    public class DeckRepository : RepositoryBase<Deck, HoLGameContext>, IDeckRepository
    {
        public DeckRepository(IDbFactory<HoLGameContext> dbFactory) : base(dbFactory)
        {
        }
    }

    public interface IDeckRepository : IRepository<Deck>
    {
    }
}
