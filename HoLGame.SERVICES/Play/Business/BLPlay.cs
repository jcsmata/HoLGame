using HoLGame.COMMONS;
using HoLGame.MODELS;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.SERVICES
{
    public interface IBLPlay
    {
        string GetDescriptionFirstCardInPlay(string gameIdentifier);
        string Play(PlayModel play);
        void StartGame(string gameIdentifier);
    }
    public class BLPlay : IBLPlay
    {
        private readonly IPlayService playService;
        private readonly IGameService gameService;
        private readonly IDeckService deckService;
        private readonly IPlayerService playerService;

        public BLPlay(IPlayService playService, IDeckService deckService, IGameService gameService, IPlayerService playerService)
        {
            this.playService = playService;
            this.deckService = deckService;
            this.gameService = gameService;
            this.playerService = playerService;
        }
        public void StartGame(string gameIdentifier)
        {

            var lstDeckIdsRandom = deckService.GetAllIdsRandom();
            var game = gameService.GetGameByGameIdentifier(gameIdentifier);

            foreach(var deckId in lstDeckIdsRandom)
            {
                var play = new Play()
                {
                    DeckId = deckId,
                    GameId = game.Id
                };

                playService.CreatePlay(play);
                playService.SavePlay();

            }
        }

        public string GetDescriptionFirstCardInPlay(string gameIdentifier)
        {
            var firstPlayByGameIdentifier = playService.GetPlaysByGameIdentifier(gameIdentifier).OrderBy(p => p.Id).FirstOrDefault();
            var gameByGameIdentifier = gameService.GetGameByGameIdentifier(gameIdentifier);

            var cardInfoByDeck = deckService.GetById(firstPlayByGameIdentifier.DeckId);

            return $"The first card from {gameByGameIdentifier.Name} game is the {cardInfoByDeck.Card.Name} of {cardInfoByDeck.Suit.SuitName}.";
        }

        public string Play(PlayModel play)
        {
            var player = playerService.GetPlayerByName(play.playerName);

            var playByGameIdentifier = playService.GetPlaysByGameIdentifier(play.gameIdentifier).Where(p => p.PlayerId == null).OrderBy(p => p.Id).Take(2);

            var currentCardInfoByDeck = deckService.GetById(playByGameIdentifier.ElementAt(0).DeckId).Card;
            var nextCardInfoByDeck = deckService.GetById(playByGameIdentifier.ElementAt(1).DeckId).Card;

            Enums.Result result = CheckResultForPlay(play.choice, currentCardInfoByDeck, nextCardInfoByDeck);

            var currentPlay = playByGameIdentifier.ElementAt(0);
            currentPlay.PlayResult = result;
            currentPlay.PlayerChoice = play.choice;
            currentPlay.PlayerId = player.Id;

            playService.UpdatePlay(currentPlay);

            return String.Empty;

        }

        private Enums.Result CheckResultForPlay(Enums.Choice choice, Card currentCardInfoByDeck, Card nextCardInfoByDeck)
        {
            if (choice == Enums.Choice.Higher && nextCardInfoByDeck.Value >= currentCardInfoByDeck.Value)
                return Enums.Result.Win;
            else
                return Enums.Result.Lose;
        }
    }
}
