using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class
{
    public class PondService : IPondService
    {
        private readonly IPondRepository _repository;
        public PondService(IPondRepository repository)
        {
            _repository = repository;
        }

        public List<int> getIdPond()
        {
            return _repository.getIdPond();
        }


    }
}
