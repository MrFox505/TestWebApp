using TestWebApp.DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        Child_DbContext db;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            db = new Child_DbContext();
            return View(await db.Gamers.ToListAsync());
        }
        public IActionResult CreateGamer()
        {
            var gamVm = new Gamer();
            return View(gamVm);
        }
        public async Task<IActionResult> CreateGamerDB(Gamer gamer)
        {
            Child_DbContext db2 = new Child_DbContext();
            db2.Gamers.Add(gamer);
            await db2.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> EditGamer(int? id)
        {
            if (id != null)
            {
                Child_DbContext db = new Child_DbContext();
                Gamer? gamer = await db.Gamers.FirstOrDefaultAsync(p => p.Id == id);
                if (gamer != null) return View(gamer);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditGamer(Gamer dog)
        {
            Child_DbContext db = new Child_DbContext();
            db.Gamers.Update(dog);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGamerDB(int? id)
        {
            if (id != null)
            {
                Child_DbContext db = new Child_DbContext();
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

        public IActionResult CreateTransaction()
        {
            var transVm = new Transaction();
            return View(transVm);
        }

        public IActionResult Privacy()
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