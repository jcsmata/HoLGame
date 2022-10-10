using HoLGame.DATA;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IDeckService
    {
        int Count();
        IEnumerable<int> GetAllIdsRandom();
        Deck GetById(int id);
    }
    public class DeckService : IDeckService
    {
        private readonly IDeckRepository deckRepository;

        public DeckService(IDeckRepository deckRepository)
        {
            this.deckRepository = deckRepository;
        }

        public int Count()
        {
            return deckRepository.GetAll().Count();
        }

        public IEnumerable<int> GetAllIdsRandom()
        {
            var rnd = new Random();

            return deckRepository.GetAll().Select(d => d.Id).OrderBy(d => rnd.Next());
        }

        public Deck GetById(int id)
        {
            return deckRepository.GetById(id);
        }
    }
}
