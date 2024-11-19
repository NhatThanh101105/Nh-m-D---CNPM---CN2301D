using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Class
{
    public class GameStatusRepository: IGameStatusRepository
    {
        private readonly KoiGameDatabaseContext _dbcontext;
        public GameStatusRepository(KoiGameDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void saveGame(int idplayer, int pondId, int playerPondId)
        {
            // Kiểm tra xem trạng thái game của người chơi đã tồn tại chưa
            var gameStatus = _dbcontext.GameStatuses.FirstOrDefault(g => g.idPlayer == idplayer);

            if (gameStatus != null)
            {
                // Nếu tồn tại, cập nhật các thuộc tính
                gameStatus.PondId = pondId;
                gameStatus.PlayerPondId = playerPondId;

                _dbcontext.GameStatuses.Update(gameStatus);
            }
            else
            {
                // Nếu chưa tồn tại, thêm mới
                gameStatus = new GameStatus
                {
                    idPlayer = idplayer,
                    PondId = pondId,
                    PlayerPondId = playerPondId
                };

                _dbcontext.GameStatuses.Add(gameStatus);
            }

            _dbcontext.SaveChanges();
        }


        public GameStatus getPlayerStatus(int idplayer)
        {
            return _dbcontext.GameStatuses.FirstOrDefault(g => g.idPlayer == idplayer);
        }

    }
}
