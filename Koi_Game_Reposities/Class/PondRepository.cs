using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Class
{
    public class PondRepository:IPondRepository
    {
        private readonly KoiGameDatabaseContext _dbcontext;
        public PondRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<int> getIdPond()
        {
            var idPond=_dbcontext.Ponds.Select(p=>p.PondId).ToList();
            return idPond;
        }
    }
}
