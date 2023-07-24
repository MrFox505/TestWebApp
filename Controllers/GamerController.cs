using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class GamerController : Controller
    {
        public IActionResult RedirectHomePage() 
        {
            return RedirectToAction("Index", "Home");
        }
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

            return RedirectToAction("RedirectHomePage");
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
            //return View("Views/Home/Index.cshtml");
            return RedirectToAction("RedirectHomePage");
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
                    return RedirectToAction("RedirectHomePage");
                }
            }
            return NotFound();
        }
    }
}
