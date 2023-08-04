using TestWebApp.DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        DataBase.Db_Context db;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
     
            using (var db = new Db_Context())
            {
                var model = new Union();
                {
                    model.gamerU = db.Gamers.ToList();
                    model.transactionU = db.Transactions.ToList();
                    model.betU = db.Bets.ToList();

                };

                return base.View(model);
            }
        }

        public IActionResult CreateTransaction()
        {
            return RedirectToAction("CreateTransaction", "Transaction");
        }
        public IActionResult EditTransaction()
        {
            return RedirectToAction("EditTransaction", "Transaction");
        }
        public IActionResult CreateBet()
        {
            return RedirectToAction("CreateBet","Bet");
        }

        public IActionResult EditBet()
        {
            return RedirectToAction("EditBet", "Bet");
        }
        public IActionResult CreateGamer()
        {
            return RedirectToAction("CreateGamer", "Gamer");
        }

        public IActionResult EditGamer()
        {
            return RedirectToAction("EditGamer", "Gamer");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}