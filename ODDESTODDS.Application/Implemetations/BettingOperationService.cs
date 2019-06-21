using Microsoft.Extensions.Caching.Memory;
using ODDESTODDS.Application.DtoModels;
using ODDESTODDS.Application.DtoModels.Game;
using ODDESTODDS.Application.DtoModels.GameOdd;
using ODDESTODDS.Application.Interface.BettingOperation;
using ODDESTODDS.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODDESTODDS.Application.Implemetations
{
    public class BettingOperationService : IBettingOperationService
    {
        private readonly IBettingRepository _bettingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public BettingOperationService(IBettingRepository bettingRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _bettingRepository = bettingRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
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

        public Task<Response<List<GamePreviewDto>>> GetCurrentGames(int status)
        {
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
