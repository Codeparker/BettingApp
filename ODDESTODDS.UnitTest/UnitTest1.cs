using Moq;
using ODDESTODDS.Application.DtoModels;
using ODDESTODDS.Application.DtoModels.Game;
using ODDESTODDS.Application.Implemetations;
using ODDESTODDS.Application.Interface.BettingOperation;
using ODDESTODDS.Controllers;
using ODDESTODDS.Domain.Entity;
using ODDESTODDS.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ODDESTODDS.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public async Task Testing_Invalid_DataTime_Value()
        {
            // Arrange
            var mockRepo = new Mock<IBettingRepository>();
            var uowRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.AddGameAsync(It.IsAny<GameInfo>()));
            uowRepo.Setup(repo => repo.CompleteAsync());
            var _sut = new BettingOperationService(mockRepo.Object, uowRepo.Object);
            CreateGameDto dto = new CreateGameDto();
            dto.GameStartTime = "1";
            //Act
            var result = await _sut.AddGame(dto);

            Assert.IsType<Response<GamePreviewDto>>(result);
            Assert.Same(result.Message, "Internal error occured , please try again");
        }

        [Fact]
        public async Task Testing_valid_DataTime_Value()
        {
            // Arrange
            var mockRepo = new Mock<IBettingRepository>();
            var uowRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.AddGameAsync(It.IsAny<GameInfo>()));
            uowRepo.Setup(repo => repo.CompleteAsync());
            var _sut = new BettingOperationService(mockRepo.Object, uowRepo.Object);
            CreateGameDto dto = new CreateGameDto();
            dto.GameStartTime = DateTime.Now.ToString();
            //Act
            var result = await _sut.AddGame(dto);

            Assert.IsType<Response<GamePreviewDto>>(result);
            Assert.Same(result.Message, "Game information successfully save");
        }
        [Fact]
        public async Task Testing_ForEmptyData_On_SaveGame()
        {
            // Arrange
            var mockRepo = new Mock<IBettingRepository>();
            var uowRepo = new Mock<IUnitOfWork>();
            mockRepo.Setup(repo => repo.AddGameAsync(It.IsAny<GameInfo>()));
            uowRepo.Setup(repo => repo.CompleteAsync());
            var _sut = new BettingOperationService(mockRepo.Object, uowRepo.Object);
            CreateGameDto dto = new CreateGameDto();
            dto.GameStartTime = DateTime.Now.ToString();
            //Act
            var result = await _sut.AddGame(dto);

            Assert.IsType<Response<GamePreviewDto>>(result);
            Assert.Same(result.Message, "Game information successfully save");
        }

        private  Response<List<GamePreviewDto>> GetTestGamesAndOdd()
        {
            var game = new List<GamePreviewDto>();
            game.Add(new GamePreviewDto()
            {
                AwayOdd = 3.4,
                HomeOdd = 4.9,
                DrawOdd = 5.0,
                HomeTeam = "Mali U20",
                AwayTeam = "China U20",
                TeamDescription = "Frances U20" + "-" + "Spain U20",
                GameStartTime = DateTime.Now

            });
            game.Add(new GamePreviewDto()
            {
                AwayOdd = 3.4,
                HomeOdd = 4.9,
                DrawOdd = 5.0,
                HomeTeam = "Frances U20",
                AwayTeam = "Spain U20",
                TeamDescription = "Frances U20" + "-" + "Spain U20",
                GameStartTime = DateTime.Now

            });
            return new Response<List<GamePreviewDto>> {Message="data found",Status=true, Result = game };
        }
    }
}
