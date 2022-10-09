using AutoMapper;
using HoLGame.MODELS;
using HoLGame.SERVICES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IBLGamePlayer
    {
        bool JoinGame(GamePlayerJoinModel gamePlayerModel);
        void CreateGamePlayer(GamePlayerJoinModel gamePlayerModel);
        bool ValidateGame(string gameIdentifier);
        bool ValidateExistingPlayers(string gameIdentifier);
        string GetPlayersNameInGame(string gameIdentifier);
    }
    public class BLGamePlayer : IBLGamePlayer
    {
        private readonly IGamePlayerService gamePlayerService;
        private readonly IGameService gameService;
        private readonly IPlayerService playerService;
        private readonly IMapper mapper;

        public BLGamePlayer(IGamePlayerService gamePlayerService, IGameService gameService, IPlayerService playerService, IMapper mapper)
        {
            this.gamePlayerService = gamePlayerService;
            this.gameService = gameService;
            this.playerService = playerService;
            this.mapper = mapper;           
        }



        public bool JoinGame(GamePlayerJoinModel gamePlayerModel)
        {
            var result = true;

            //Validate if game exists

            //Validade number of players
            if (!ValidateNumberOfPlayers(gamePlayerModel.GameIdentifier))
                return false;

            CreateGamePlayer(gamePlayerModel);

            return result;
        }

        public void CreateGamePlayer(GamePlayerJoinModel gamePlayerModel)
        {
            var gameId = gameService.GetGameByGameIdentifier(gamePlayerModel.GameIdentifier).Id;
            var playerId = playerService.GetPlayerByName(gamePlayerModel.PlayerName).Id;

            gamePlayerModel.PlayerId = playerId;
            gamePlayerModel.GameId = gameId;


            var gamePlayer = mapper.Map<GamePlayer>(gamePlayerModel);

            gamePlayerService.CreateGamePlayer(gamePlayer);
            gamePlayerService.SaveGamePlayer();

        }

        public bool ValidateGame(string gameIdentifier)
        {
            var game = gameService.GetGameByGameIdentifier(gameIdentifier);

            return (game == null);
        }

        public bool ValidateExistingPlayers(string gameIdentifier)
        {
            var numberOfPlayersInGame = gamePlayerService.GetNumberOfPlayersInGame(gameIdentifier);
            var maxNumberOfPlayersInGame = gameService.GetMaxNumberOfPlayersInGameByGameIdentifier(gameIdentifier);

            return numberOfPlayersInGame == maxNumberOfPlayersInGame;
        }

        public string GetPlayersNameInGame(string gameIdentifier)
        {
            var lstPlayerNamesInGame = gamePlayerService.GetPlayersNameInGame(gameIdentifier);

            return string.Join(",", lstPlayerNamesInGame);
        }


        private bool ValidateNumberOfPlayers(string gameIdentifier)
        {
            var numberOfPlayersInGame = gamePlayerService.GetNumberOfPlayersInGame(gameIdentifier);
            var maxNumberOfPlayersInGame = gameService.GetMaxNumberOfPlayersInGameByGameIdentifier(gameIdentifier);

            return (maxNumberOfPlayersInGame != null && numberOfPlayersInGame < maxNumberOfPlayersInGame);
        }
    }
}
