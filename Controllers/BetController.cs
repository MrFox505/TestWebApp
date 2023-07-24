using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class BetController : Controller
    {
        public IActionResult RedirectHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
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

            return RedirectToAction("RedirectHomePage");
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
            return RedirectToAction("RedirectHomePage");
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
                    return RedirectToAction("RedirectHomePage");
                }
            }
            return NotFound();
        }
    }
}
