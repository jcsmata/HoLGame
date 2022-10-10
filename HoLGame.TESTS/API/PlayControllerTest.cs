using HoLGame.API.Controllers;
using HoLGame.SERVICES;
using Microsoft.AspNetCore.Http;
using Moq;
using NuGet.Packaging.Signing;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.TESTS
{
    public class PlayControllerTest
    {
        private PlayController controller;

        private Mock<IBLGamePlayer> blGamePlayerMock;
        private Mock<IBLPlay> blPlayMock;

        private GamePlayerJoinModel gamePlayerMock;
        private PlayModel playMock;

        [SetUp]
        public void Setup()
        {
            blGamePlayerMock = new Mock<IBLGamePlayer>();
            blPlayMock = new Mock<IBLPlay>();

            gamePlayerMock = new GamePlayerJoinModel();
            playMock = new PlayModel();

            controller = new PlayController(blGamePlayerMock.Object, blPlayMock.Object);
        }

        [Test]
        public void JoinGameReturnStatus200OK()
        {
            //Arranje
            gamePlayerMock.PlayerName = "Teste Name";
            gamePlayerMock.GameIdentifier = Guid.NewGuid().ToString();

            blGamePlayerMock.Setup(b => b.JoinGame(gamePlayerMock)).Returns(true);

            //act
            var result = controller.JoinGame(gamePlayerMock);
            
            
            //Assert
            Assert.That(((Microsoft.AspNetCore.Mvc.StatusCodeResult)result).StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void JoinGameReturnStatus400BadRequest()
        {
            //Arranje
            gamePlayerMock.PlayerName = "Teste Name";
            gamePlayerMock.GameIdentifier = Guid.NewGuid().ToString();

            blGamePlayerMock.Setup(b => b.JoinGame(gamePlayerMock)).Returns(false);

            //act
            var result = controller.JoinGame(gamePlayerMock);


            //Assert
            Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, Is.EqualTo(400));
        }

        [Test]
        public void StartGameReturnStatus400BadRequest()
        {
            blGamePlayerMock.Setup(b => b.ValidateExistingPlayers("")).Returns(false);

            //act
            var result = controller.StartGame("");

            //assert
            Assert.That((string?)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value, Is.EqualTo("Still waiting for all players to register!"));
        }

        [Test]
        public void StartGameReturnStatus200Ok()
        {
            //arrange
            blGamePlayerMock.Setup(b => b.ValidateExistingPlayers("")).Returns(true);

            //act
            var result = controller.StartGame("");

            //assert
            Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GameScoreReturnStatus200Ok()
        {
            //arrange
            blPlayMock.Setup(b => b.GameScore("")).Returns("Score");

            //act
            var result = controller.GameScore("");

            //assert
            Assert.That(((Microsoft.AspNetCore.Mvc.ObjectResult)result).StatusCode, Is.EqualTo(200));
        }
    }
}
