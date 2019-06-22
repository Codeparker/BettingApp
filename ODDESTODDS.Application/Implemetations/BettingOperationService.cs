using Microsoft.Extensions.Caching.Memory;
using ODDESTODDS.Application.DtoModels;
using ODDESTODDS.Application.DtoModels.Game;
using ODDESTODDS.Application.DtoModels.GameOdd;
using ODDESTODDS.Application.Interface.BettingOperation;
using ODDESTODDS.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ODDESTODDS.Domain.Entity;

namespace ODDESTODDS.Application.Implemetations
{
    public class BettingOperationService : IBettingOperationService
    {
        private readonly IBettingRepository _bettingRepository;
        private readonly IUnitOfWork _unitOfWork;
      

        public BettingOperationService(IBettingRepository bettingRepository, IUnitOfWork unitOfWork)
        {
            _bettingRepository = bettingRepository;
            _unitOfWork = unitOfWork;
        
        }
        public async Task<Response<GamePreviewDto>> AddGame(CreateGameDto data)
        {

            var model = new GameInfo()
            {
                AwayTeam = data.AwayTeam,
                HomeTeam = data.HomeTeam,
                GameStartTime = data.GameStartTime,
                GameStatus = data.GameStatus,
                GameOdd = new GameOdd() { AwayOdd = data.AwayOdd, HomeOdd = data.HomeOdd, DrawOdd = data.DrawOdd }
            };
            await _bettingRepository.AddAsync(model);
            await _unitOfWork.CompleteAsync();
            return new Response<GamePreviewDto>
            {
                Status = true,
                Message = $"Game information successfully save",
                Result = new GamePreviewDto() {

                    TeamDescription = $"{model.HomeTeam} - {model.AwayTeam}",
                    HomeOdd = model.GameOdd.HomeOdd,
                    AwayOdd = model.GameOdd.AwayOdd,
                    DrawOdd = model.GameOdd.DrawOdd,
                    GameStartTime = model.GameStartTime,
                    GameStatusDescription = Enum.GetName(typeof(Enums.GameStatus), model.GameStatus),
                    GameId = model.GameStatus,
                    Id = model.Id,
                }

            };

        }

        public async Task<Response<List<GamePreviewDto>>> GetCurrentGames(int status)
        {
            var response =  await _bettingRepository.GameListAsync();
            if (response == null)
            {
                return new Response<List<GamePreviewDto>>
                {
                    Status = true,
                    Message = $"{response.Count()} Current game data not found",
                    Result = default(List<GamePreviewDto>)

                };
            }
            var clientResponse = new Response<List<GamePreviewDto>>
            {
                Status = true,
                Message = $"{response.Count()} Current game data found",
                Result = response.ToList()?.Select(item => new GamePreviewDto()
                {
                   TeamDescription=$"{item.HomeTeam} - {item.AwayTeam}",
                   HomeOdd=item.GameOdd.HomeOdd,
                   AwayOdd = item.GameOdd.AwayOdd,
                   DrawOdd = item.GameOdd.DrawOdd,
                   GameStartTime=item.GameStartTime,
                   GameStatusDescription= Enum.GetName(typeof(Enums.GameStatus), item.GameStatus),
                   GameId=item.GameStatus,
                   Id=item.Id,
                   

                }).ToList()

            };
            return clientResponse;
           
        }

        public Task<Response<List<GameOddPreviewDto>>> GetGameOdd(int gameId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> UpdateGame(CreateGameDto model)
        {
            throw new NotImplementedException();
        }
    }
}
