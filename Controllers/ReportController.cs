using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApp.DataBase;
using TestWebApp.Models;
using static TestWebApp.Models.Gamer;

namespace TestWebApp.Controllers
{
    public class ReportController : Controller
    {

        public IActionResult Index()
        {
            
            return View("Report");
        }
        
        public async Task<IActionResult> CreateReport(EnumStatus Status, bool SelectionChecked)
        {
            if (Status == EnumStatus.Новый)
            {

            }
            //IEnumerable<Gamer> gamer;
            Db_Context db = new Db_Context();
            ReportModel reportR = new ReportModel();
            reportR.gamerR = db.Gamers.ToList();
            return View("Report", reportR);
        }

        //в запросе использовать AsNoTracking()
    }
}
