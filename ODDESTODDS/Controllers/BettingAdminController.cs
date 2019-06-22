using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODDESTODDS.Application.DtoModels.Game;
using ODDESTODDS.Application.Interface.BettingOperation;
using PusherServer;

namespace ODDESTODDS.Controllers
{
  
    public class BettingAdminController : Controller
    {
        private readonly IBettingOperationService _bettingService;
        public BettingAdminController(IBettingOperationService bettingService)
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

      
        public IActionResult AddorEdit(long Id=0)
        {
            if (Id == 0)
                return View(new CreateGameDto());
            else
              
                return View(_bettingService.GetGameForEdit(Id).Result.Result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("HomeTeam,AwayTeam,HomeOdd,AwayOdd,DrawOdd,GameStartTime")] CreateGameDto model)
        {
            if (ModelState.IsValid)
            {
                 await _bettingService.AddGame(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);




        }

       
        public async Task<IActionResult> Delete(long Id)
        {
            await _bettingService.DeleteGames(Id);
            return RedirectToAction(nameof(Index));
           
        }
        

    }
}