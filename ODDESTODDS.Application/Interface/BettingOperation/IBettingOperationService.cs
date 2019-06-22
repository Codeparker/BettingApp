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
        Task<Response<GamePreviewDto>> AddGame(CreateGameDto model);

        
        Task<Response<List<GamePreviewDto>>> GetCurrentGames(int status);


        Task<Response<CreateGameDto>> GetGameForEdit(long Id);
        Task<Response<GamePreviewDto>> GetGameById(long Id);

        Response<string> UpdateGame(CreateGameDto model);

        Task<Response<string>> DeleteGames(long Id);

        Task<Response<string>> DeleteOdd(long Id);



    }
}
