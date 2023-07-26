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
        [HttpPost]
        public async Task<IActionResult> CreateReport(ReportModel reportR)
        {
            if (reportR.Status == 0)
            {

            }
            //IEnumerable<Gamer> gamer;
            Db_Context db = new Db_Context();
            reportR.gamerR = db.Gamers.ToList();
            return View("Report", reportR);
        }

        //в запросе использовать AsNoTracking()
    }
}
