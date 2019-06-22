using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODDESTODDS.Application.DtoModels.Game;
using ODDESTODDS.Application.Interface.BettingOperation;

namespace ODDESTODDS.Controllers
{

    [Route("api/[controller]")]
    public class BettingGuestController : Controller
    {
        private readonly IBettingOperationService _bettingService;
        public BettingGuestController(IBettingOperationService bettingService)
        {
            _bettingService = bettingService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _bettingService.GetCurrentGames((int)Application.Enums.GameStatus.Inprogress);
            ViewData["game_list"] = response.Result;
            return View();
        }
        [HttpGet]
        [Route("api/[controller]/GetAll")]
        public async Task<IEnumerable<GamePreviewDto>> GetAll()
        {

            var response = await _bettingService.GetCurrentGames((int)Application.Enums.GameStatus.AllGame);
            return response.Result;
        }

    }
}