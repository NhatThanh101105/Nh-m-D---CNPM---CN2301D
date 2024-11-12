﻿using Koi_Game_Reposities.Entities;
using Koi_Game_Reposities.Interfaces;
using Koi_Game_Services.DTO;
using Koi_Game_Services.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koi_Game_Services.Class.player
{
    public class PlayerService : IPlayerService
    {


        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void AddPlayer(PlayerDTO playerDTO)
        {
            var player = new Player
            {
                Name = playerDTO.Name,
                UserName = playerDTO.UserName,
                Password = playerDTO.Password,
                Coin = 0
            };
            _playerRepository.AddPlayer(player);
        }

        public void DeletePlayer(PlayerDTO playerDTO)
        {
            var player = new Player
            {
                PlayerId = playerDTO.Id,
                Name = playerDTO.Name,
                UserName = playerDTO.UserName,
                Password = playerDTO.Password,
                Coin = playerDTO.Coin
            };
            _playerRepository.DelPlayer(player);
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await _playerRepository.GetAllPlayer();
        }

        public async Task<Player> GetPlayer(int id)
        {
            return await _playerRepository.GetPlayer(id);

        }

        public void UpdatePlayer(Player player)
        {
            
            _playerRepository.UpdatePlayer(player);
        }

        public async Task<decimal?> GetCoinPlayer(int id)
        {
            var player = await _playerRepository.GetPlayer(id);
            if (player != null)
            {
                decimal? coin = player.Coin;
                return coin;
            }
            return 0;
        }
    }
}
