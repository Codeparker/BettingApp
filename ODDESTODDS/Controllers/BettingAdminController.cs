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
    [Route("api/[controller]")]
    public class BettingAdminController : Controller
    {
        private readonly IBettingOperationService _bettingService;
        public BettingAdminController(IBettingOperationService bettingService)
        {
            _bettingService = bettingService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index([FromForm] CreateGameDto model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return new ObjectResult(
                    new { status = false, message = "incomplete request",result="" }
                );
            }
            var response = await _bettingService.AddGame(model);
            if (response.Status == true)
            {
                var options = new PusherOptions
                {
                    Cluster = "eu",
                    Encrypted = true
                };
                var pusher = new Pusher("PUSHER_APP_ID","PUSHER_APP_KEY","PUSHER_APP_SECRET", options);
                var result = await pusher.TriggerAsync("bet_channel", "bet_event", new { response.Message });
                return new ObjectResult(new { status = "success", data = response.Result });
            }

            return new ObjectResult(new { status = false, message = response.Message, result = response.Result } );




        }
    }
}