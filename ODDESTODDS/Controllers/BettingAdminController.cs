using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODDESTODDS.Application.DtoModels.Game;
using ODDESTODDS.Application.Interface.BettingOperation;
using ODDESTODDS.Helpers;

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
            var response = await _bettingService.GetCurrentGames(0);
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
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("Id,OddId,HomeTeam,AwayTeam,HomeOdd,AwayOdd,DrawOdd,GameStartTime")] CreateGameDto model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id>0 && model.OddId>0)
                  await _bettingService.UpdateGame(model);
                else
                   await _bettingService.AddGame(model);
                await ChannelHelper.Trigger(model, "betting", "game_event");
                return RedirectToAction(nameof(Index));
            }
            return View(model);




        }

       
        public async Task<IActionResult> Delete(long Id)
        {
            await _bettingService.DeleteGames(Id);
            await ChannelHelper.Trigger(Id, "betting", "game_event");
            return RedirectToAction(nameof(Index));
           
        }
        

    }
}