using ODDESTODDS.Application.DtoModels;
using ODDESTODDS.Application.DtoModels.Game;
using ODDESTODDS.Application.DtoModels.GameOdd;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODDESTODDS.Application.Interface.BettingOperation
{
    public interface IBettingOperationService
    {
        Task<Response<string>> AddGame(CreateGameDto model);

        Task<Response<string>> AddOdd(CreateGameOddDto model);
        Task<Response<List<GamePreviewDto>>> GetCurrentGames(int status);

        Task<Response<List<GameOddPreviewDto>>> GetGameOdd(int gameId);

        Task<Response<string>> UpdateGame(CreateGameDto model);



    }
}
