using HoLGame.DATA;
using HoLGame.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface ISuitService
    {
        IEnumerable<Suit> GetAll();
    }
    public class SuitService : ISuitService
    {
        private readonly ISuitRepository suitRepository;

        public SuitService(ISuitRepository suitRepository)
        {
            this.suitRepository = suitRepository;
        }

        public IEnumerable<Suit> GetAll()
        {
            return suitRepository.GetAll();
        }
    }
}
