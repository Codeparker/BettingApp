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
using System.Globalization;

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
            try
            {
                var gamestart = DateTime.Parse(data.GameStartTime);
                var model = new GameInfo()
                {
                    AwayTeam = data.AwayTeam,
                    HomeTeam = data.HomeTeam,
                    GameStartTime = gamestart,
                    GameStatus = data.GameStatus,
                    GameOdd = new GameOdd() { AwayOdd = data.AwayOdd, HomeOdd = data.HomeOdd, DrawOdd = data.DrawOdd }
                };
                await _bettingRepository.AddGameAsync(model);
                await _unitOfWork.CompleteAsync();
                return new Response<GamePreviewDto>
                {
                    Status = true,
                    Message = $"Game information successfully save",
                    Result = new GamePreviewDto()
                    {

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
            catch (Exception ex)
            {
                return new Response<GamePreviewDto>
                {
                    Status = false,
                    Message = $"{ex.Message}:Internal error occured , please try again",
                    Result = default(GamePreviewDto)

                };
            }
            

        }

        public async Task<Response<string>> DeleteGames(long Id)
        {
            try
            {
                var game = await _bettingRepository.FindGameByIdAsync(Id);
                if (game == null)
                {
                    return new Response<string>
                    {
                        Status = false,
                        Message = $"Invalid Id , please selete a valid Id",
                        Result = default(string)

                    };
                }
                 _bettingRepository.RemoveGame(game);
                await  _unitOfWork.CompleteAsync();
                return new Response<string>
                {
                    Status = true,
                    Message = $"Operation completed",
                    Result = default(string)

                };
            }
            catch(Exception ex)
            {
                return new Response<string>
                {
                    Status = false,
                    Message = $"{ex.Message}:Internal error occured , please try again",
                    Result = default(string)

                };
            }
        }

        public async Task<Response<string>> DeleteOdd(long Id)
        {
            try
            {
                var gameoddd = await _bettingRepository.FindGameOddByIdAsync(Id);
                if (gameoddd == null)
                {
                    return new Response<string>
                    {
                        Status = false,
                        Message = $"Invalid Id , please selete a valid Id",
                        Result = default(string)

                    };
                }
                gameoddd.AwayOdd = 0;
                gameoddd.AwayOdd = 0;
                gameoddd.HomeOdd = 0;
                _bettingRepository.RemoveOdd(gameoddd);
                await _unitOfWork.CompleteAsync();
                return new Response<string>
                {
                    Status = true,
                    Message = $"Operation Completed!",
                    Result = default(string)

                };
            }
            catch (Exception ex)
            {
                return new Response<string>
                {
                    Status = false,
                    Message = $"{ex.Message}:Internal error occured , please try again",
                    Result = default(string)

                };
            }
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
            return new Response<List<GamePreviewDto>>
            {
                Status = true,
                Message = $"{response.Count()} Current game data found",
                Result = response.ToList()?.Select(item => new GamePreviewDto()
                {
                   TeamDescription=$"{item.HomeTeam} - {item.AwayTeam}",
                   HomeOdd=item.GameOdd.HomeOdd,
                   AwayOdd = item.GameOdd.AwayOdd,
                   DrawOdd = item.GameOdd.DrawOdd,
                    HomeTeam = item.HomeTeam,
                    AwayTeam = item.AwayTeam,
                    GameStartTime =item.GameStartTime,
                   GameStatusDescription= Enum.GetName(typeof(Enums.GameStatus), item.GameStatus),
                   GameStatus=item.GameStatus,
                   Id=item.Id,
                   GameId=item.Id


                }).ToList()

            };
           
           
        }

        public async Task<Response<GamePreviewDto>> GetGameById(long Id)
        {
            var response = await _bettingRepository.FindGameByIdAsync(Id);
            if (response == null)
            {
                return new Response<GamePreviewDto>
                {
                    Status = true,
                    Message = $"game data not found",
                    Result = default(GamePreviewDto)

                };
            }
            return new Response<GamePreviewDto>
            {
                Status = true,
                Message = $"Current game data found",
                Result =  new GamePreviewDto()
                {
                    TeamDescription = $"{response.HomeTeam} - {response.AwayTeam}",
                    HomeTeam= response.HomeTeam,
                    AwayTeam= response.AwayTeam,
                    HomeOdd = response.GameOdd.HomeOdd,
                    AwayOdd = response.GameOdd.AwayOdd,
                    DrawOdd = response.GameOdd.DrawOdd,
                    GameStartTime = response.GameStartTime,
                    GameStatusDescription = Enum.GetName(typeof(Enums.GameStatus), response.GameStatus),
                    GameStatus = response.GameStatus,
                    Id = response.Id,
                    GameId = response.Id


                }

            };
        }

        public async Task<Response<CreateGameDto>> GetGameForEdit(long Id)
        {
            var response = await _bettingRepository.FindGameByIdAsync(Id);
            if (response == null)
            {
                return new Response<CreateGameDto>
                {
                    Status = true,
                    Message = $"game data not found",
                    Result = default(CreateGameDto)

                };
            }
            return new Response<CreateGameDto>
            {
                Status = true,
                Message = $"Current game data found",
                Result = new CreateGameDto()
                {
                    
                    HomeTeam = response.HomeTeam,
                    AwayTeam = response.AwayTeam,
                    HomeOdd = response.GameOdd.HomeOdd,
                    AwayOdd = response.GameOdd.AwayOdd,
                    DrawOdd = response.GameOdd.DrawOdd,
                    GameStartTime = response.GameStartTime.ToString(),
                    GameStatus = response.GameStatus,
                    Id = response.Id,
                    


                }

            };
        }

        public Response<string> UpdateGame(CreateGameDto model)
        {
            try
            {
                var gamestart = Convert.ToDateTime(model.GameStartTime);
                var game = new GameInfo()
                {
                    AwayTeam = model.AwayTeam,
                    HomeTeam = model.HomeTeam,
                    GameStartTime = gamestart,
                    GameStatus = model.GameStatus,
                    Id= model.Id,
                    GameOdd = new GameOdd() { AwayOdd = model.AwayOdd, HomeOdd = model.HomeOdd, DrawOdd = model.DrawOdd }
                };
                var response =  _bettingRepository.UpdateGame(game);
                return new Response<string>
                {
                    Status = true,
                    Message = $"Operation completed",
                    Result = default(string)

                };
            }
            catch (Exception ex) {
                return new Response<string>
                {
                    Status = false,
                    Message = $"{ex.Message}:Internal error occured , please try again",
                    Result = default(string)

                };
            }
        }
    }
}
