using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ODDESTODDS.Application.Interface.BettingOperation;

namespace ODDESTODDS.Controllers
{
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
    }
}