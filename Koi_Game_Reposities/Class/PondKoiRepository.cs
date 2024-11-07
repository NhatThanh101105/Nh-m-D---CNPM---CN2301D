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
        public async Task<bool> addKoiToPond(int playerKoiId, int playerPondId,int idplayer)
        {
            // tim ca koi cua nguoiw choi
            var playerKoi = await _dbcontext.PlayerKoi.
                FirstOrDefaultAsync(pk => pk.PlayerKoiId == playerKoiId && pk.PlayerId == idplayer);

            // tim ho cua nguoi choi, doongf thoi deem luoon soo cas dax cos trong hoof
            var playerPond = await _dbcontext.PlayerPonds
                .Include(pp => pp.Pond)
                .Include(pp => pp.PondKois)
                .FirstOrDefaultAsync(pp=>pp.PlayerPondId==playerPondId&& pp.PlayerId==idplayer);

            if (playerPond == null || playerKoi ==null)
            {
                return false;
            }
            // neu ca trong hoo daayf thif trar veef false
            if (playerPond.PondKois.Count >= playerPond.Pond.Capacity)
            {
                return false;
            }
            // chua day thi batw dauf them cas

            var pondKoi = new PondKoi
            {
                PlayerKoiId = playerKoiId,
                PlayerPondId = playerPondId,
            };
            _dbcontext.PondKois.Add(pondKoi);
            _dbcontext.SaveChanges();
            return true;
        }

        public List<int> getKoiPlayer(int playerID)
        {
            return _dbcontext.PlayerKoi
                .Where(pk=>pk.PlayerId == playerID && !_dbcontext.PondKois.Any(p=>p.PlayerKoiId==pk.PlayerKoiId))
                .Select(pk=>pk.KoiId.Value)
                .ToList();
        }
        public async Task<bool> removeKoiFromPond(int playerKoiId, int playerPondid, int idplayer)
        {
            
            var playerKoi = await _dbcontext.PlayerKoi
                .FirstOrDefaultAsync(pk => pk.PlayerKoiId == playerKoiId && pk.PlayerId == idplayer);
            var playerPond= await _dbcontext.PlayerPonds
                .FirstOrDefaultAsync(pp=>pp.PlayerPondId==playerPondid&& pp.PlayerId==idplayer);   

            if(playerKoi==null || playerPond ==null) return false;

            var pondKoi=await _dbcontext.PondKois
                .FirstOrDefaultAsync(pk=>pk.PlayerPondId==playerPondid && pk.PlayerKoiId==playerKoiId);
            if (pondKoi==null) return false;


            _dbcontext.PondKois.Remove(pondKoi);
            _dbcontext.SaveChanges();
            return true;

        }
        public List<int> getKoiInPond(int idplayer,int PondId)
        {
            //doan nay tí chinhgr sửa
            return _dbcontext.PondKois
                .Where(pk=>pk.PlayerPondId==PondId&&pk.PlayerKoi.PlayerId==idplayer)
                .Select(pk=>pk.PlayerKoi.KoiId ?? 0)
                .Where(koiId=>koiId!= 0)
                .ToList();
        }



        public  List<PlayerKoi> GetKoiInPond(int idplayer,int playerPondId)
        {

            var playerPond =  _dbcontext.PlayerPonds
                .Include(pp => pp.PondKois)
                .ThenInclude(pk => pk.PlayerKoi)
                .ThenInclude(k => k.Koi)
                .FirstOrDefault(pp => pp.PlayerPondId == playerPondId && pp.PlayerId == idplayer);

            if (playerPond == null) return new List<PlayerKoi>();

            var KoiList =  playerPond.PondKois
                .Select(pk=>pk.PlayerKoi)
                .Where(pk=>pk!=null)
                .ToList();


            return KoiList;
        }
    }
}
