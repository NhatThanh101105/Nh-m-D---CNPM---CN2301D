﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Reposities.Interfaces
{
    public interface IGameStatusRepository
    {
        int getPondId(int idplayer);
        int getPlayerPondId(int idplayer);
    }
}
