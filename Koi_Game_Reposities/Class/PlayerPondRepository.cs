using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Class
{
    public class PlayerPondRepository : IPlayerPondRepository
    {
        private readonly KoiGameDatabaseContext _dbcontext;
        public PlayerPondRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<PlayerPond> getPlayerPond(int idplayer)
        {
            return _dbcontext.PlayerPonds.Where(pp=>pp.PlayerId== idplayer).ToList();
        }
        public int getPlayerPondId(int idplayer,int pondId)
        {
            var playerpond= _dbcontext.PlayerPonds.FirstOrDefault(pp=>pp.PlayerId == idplayer&& pp.PondId==pondId);
            if (playerpond == null) return 0;
            return playerpond.PlayerPondId;
        }

        public void addPondToPlayer(int idplayer, int pondId)
        {
            var playerPond = new PlayerPond
            {
                PlayerId = idplayer,
                PondId = pondId
            };
            _dbcontext.PlayerPonds.Add(playerPond);
            _dbcontext.SaveChanges();
        }
    }
}
