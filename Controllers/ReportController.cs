using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApp.DataBase;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class ReportController : Controller
    {

        public IActionResult Index()
        {
            return View("Report");
        }

        public async Task<IActionResult> CreateReport()
        {
            //IEnumerable<Gamer> gamer;
            Db_Context db = new Db_Context();

            //gamer = ;
            return View("Report", await db.Gamers.ToListAsync());
        }
    }
}
