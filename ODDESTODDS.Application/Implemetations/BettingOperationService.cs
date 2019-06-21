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
        public async  Task<Response<string>> AddGame(CreateGameDto model)
        {
            await _unitOfWork.CompleteAsync();
            throw new NotImplementedException();
        }

        public Task<Response<string>> AddOdd(CreateGameOddDto model)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
