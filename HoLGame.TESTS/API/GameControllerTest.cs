using HoLGame.API.Controllers;
using HoLGame.SERVICES;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoLGame.TESTS
{
    public class GameControllerTest
    {
        private GameController controller;
        private Mock<IBLGame> blGameMock;
        private GameModel gameModelMock;


        [SetUp]
        public void Setup()
        {
            blGameMock = new Mock<IBLGame>();

            gameModelMock = new GameModel();

            //arrange
            gameModelMock.Name = "teste";
            gameModelMock.NumberPlayers = 2;

            blGameMock.Setup(b => b.CreateGame(gameModelMock)).Returns("guid");

            controller = new GameController(blGameMock.Object);


        }

        [Test]
        public void ShouldReturnValidGuid()
        {
            //act
            var result = controller.CreateGame(gameModelMock);

            //assert
            Assert.That(true, (string?)((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value, "guid");
        }
    }
}
