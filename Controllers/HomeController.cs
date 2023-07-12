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
            //db = new Child_DbContext();
            //return View(await db.Gamers.ToListAsync());
            using (var db = new DataBase.Db_Context())
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
        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateGamer()
        {
            var gamVm = new Gamer();
            return View(gamVm);
        }
        public async Task<IActionResult> CreateGamerDB(Gamer gamer)
        {
            DataBase.Db_Context db2 = new DataBase.Db_Context();
            db2.Gamers.Add(gamer);
            await db2.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditGamer(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                Gamer? gamer = await db.Gamers.FirstOrDefaultAsync(p => p.Id == id);
                if (gamer != null) return View(gamer);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditGamer(Gamer gamer)
        {
            DataBase.Db_Context db = new DataBase.Db_Context();
            db.Gamers.Update(gamer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGamerDB(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                Gamer? gamer = await db.Gamers.FirstOrDefaultAsync(p => p.Id == id);
                if (gamer != null)
                {
                    db.Gamers.Remove(gamer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        /// <summary>
        /// /////////
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateTransaction()
        {
            var transVm = new Transaction();
            return View(transVm);
        }
        public async Task<IActionResult> CreateTransactionDB(Transaction transaction)
        {
            DataBase.Db_Context db2 = new DataBase.Db_Context();
            db2.Transactions.Add(transaction);
            await db2.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditTransaction(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                Transaction? transaction = await db.Transactions.FirstOrDefaultAsync(p => p.Id == id);
                if (transaction != null) return View(transaction);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditTransaction(Transaction transaction)
        {
            DataBase.Db_Context db = new DataBase.Db_Context();
            db.Transactions.Update(transaction);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTransactionDB(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                Transaction? transaction = await db.Transactions.FirstOrDefaultAsync(p => p.Id == id);
                if (transaction != null)
                {
                    db.Transactions.Remove(transaction);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        /// <summary>
        /// ////////////////////////
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateBet()
        {
            var betVm = new Bet();
            return View(betVm);
        }
        public async Task<IActionResult> CreateBetDB(Bet bet)
        {
            DataBase.Db_Context db2 = new DataBase.Db_Context();
            db2.Bets.Add(bet);
            await db2.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditBet(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                Bet? bet = await db.Bets.FirstOrDefaultAsync(p => p.Id == id);
                if (bet != null) return View(bet);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditBet(Bet bet)
        {
            DataBase.Db_Context db = new DataBase.Db_Context();
            db.Bets.Update(bet);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBetDB(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                Bet? bet = await db.Bets.FirstOrDefaultAsync(p => p.Id == id);
                if (bet != null)
                {
                    db.Bets.Remove(bet);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
        /// <summary>
        /// //////////
        /// </summary>
        /// <returns></returns>
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