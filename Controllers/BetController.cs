using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class BetController : Controller
    {
        private static Bet? betEdit;
        public IActionResult RedirectHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CreateBet()
        {
            var betVm = new Bet();
            DataBase.Db_Context db = new DataBase.Db_Context();
            ViewData["GamerId"] = new SelectList(db.Gamers, "Id", "FullName");
            return View(betVm);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBetDB(Bet bet)
        {
            DataBase.Db_Context db = new DataBase.Db_Context();
            Gamer? gamer = await db.Gamers.FirstOrDefaultAsync(g => g.Id == bet.GamerId);
            if (gamer != null)
            {
                gamer.Balance -= bet.Sum;
                db.Gamers.Update(gamer);
                await db.SaveChangesAsync();
            }
            db.Bets.Add(bet);
            await db.SaveChangesAsync();

            return RedirectToAction("RedirectHomePage");
        }
        public async Task<IActionResult> EditBet(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                betEdit = await db.Bets.FirstOrDefaultAsync(p => p.Id == id);
                ViewData["GamerId"] = new SelectList(db.Gamers, "Id", "FullName");
                if (betEdit != null) return View(betEdit);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditBet(Bet bet)
        {
            DataBase.Db_Context db = new DataBase.Db_Context();
            Gamer? gamer = await db.Gamers.FirstOrDefaultAsync(p => p.Id == bet.GamerId);
            if (gamer != null)
            {
                if (betEdit.Sum != bet.Sum)
                {
                    gamer.Balance += (betEdit.Sum - bet.Sum);
                    db.Gamers.Update(gamer);
                    await db.SaveChangesAsync();
                }                
            }
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
