using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Class
{
    public class PondKoiRepository : IPondKoiRepository
    {
        private readonly KoiGameDatabaseContext _dbcontext;
        public PondKoiRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void addKoiToPond(int playerKoiId, int PondId)
        {
            var pondKoi=_dbcontext.PondKois.FirstOrDefault(pk=>pk.PlayerKoiId == playerKoiId);
            if (pondKoi == null)
            {
                pondKoi = new PondKoi
                {
                    PondId = PondId,
                    PlayerKoiId = playerKoiId
                };
                _dbcontext.PondKois.Add(pondKoi);
            }
            else {
                pondKoi.PondId = PondId;
            }
            _dbcontext.SaveChanges();
        }

        public List<int> getKoiPlayer(int playerID)
        {
            return _dbcontext.PlayerKoi
                .Where(pk=>pk.PlayerId == playerID && !_dbcontext.PondKois.Any(p=>p.PlayerKoiId==pk.PlayerKoiId))
                .Select(pk=>pk.KoiId.Value)
                .ToList();
        }
        public void removeKoiFromPond(int playerKoiId)
        {
            var pondKoi = _dbcontext.PondKois.FirstOrDefault(pk=>pk.PlayerKoiId==playerKoiId);
            if (pondKoi != null)
            {
                _dbcontext.PondKois.Remove(pondKoi);
                _dbcontext.SaveChanges();
            }
        }
        public List<int> getKoiInPond(int idplayer,int PondId)
        {
            return _dbcontext.PondKois
                .Where(pk=>pk.PondId==PondId&&pk.PlayerKoi.PlayerId==idplayer)
                .Select(pk=>pk.PlayerKoi.KoiId ?? 0)
                .Where(koiId=>koiId!= 0)
                .ToList();
        }
    }
}
