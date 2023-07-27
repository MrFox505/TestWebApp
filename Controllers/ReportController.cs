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
            Db_Context db = new Db_Context();

            //var gamer = from g in db.Gamers
            //            where g.Status == Status
            //            select g;

            var gamer = from g in db.Gamers
                        join j in db.Bets on g.Id equals j.GamerId
                        where g.Status == Status
                        select g;

            var gamerL = gamer.ToList();
            if (SelectionChecked == true)
            {//сумма внесений
                var Trans = db.Transactions.Where(p => p.TypeOperation == 0)
                    .GroupBy(g => g.GamerId)
                      .Select(p => new Transaction
                      {
                          GamerId = p.Key,
                          Sum = p.Sum(x => x.Sum)
                      });
                //сумма ставок
               
                var listSum = Trans.ToList();
            };


            ReportModel reportR = new ReportModel();
            reportR.gamerR = gamer.ToList();
            return View("Report", reportR);
        }

        //в запросе использовать AsNoTracking()
    }
}
