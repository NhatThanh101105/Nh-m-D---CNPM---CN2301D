﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Interfaces
{
    public interface IPondKoiService
    {
        List<int> getKoiPlayer(int playerId);
        void addKoiToPond(int playerId, int pondId);
    }
}