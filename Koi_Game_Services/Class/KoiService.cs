﻿using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _koiRepository;
        public KoiService(IKoiRepository koiRepository)
        {
            _koiRepository = koiRepository;
        }
        public async Task<List<KoiFish>> GetAllKoiFishes()
        {
            return await _koiRepository.GetAllKoiFishs();
        }

        public async Task<KoiFish> GetKoiFishById(int id)
        {
            return await _koiRepository.GetKoiFishById(id);
        }
    }
}
