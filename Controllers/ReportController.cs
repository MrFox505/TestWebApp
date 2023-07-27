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
            ReportModel reportR = new ReportModel();
            //игроки с нужным статусом
            //var gamer = from g in db.Gamers
            //            where g.Status == Status
            //            select g;
            var gamer = db.Gamers.Where(p => p.Status == Status);
            if (SelectionChecked == true)
            {
                var gamerBet = gamer.GroupJoin(db.Bets, g => g.Id, b => b.GamerId, (g, c) => new
                {
                    Id = g.Id,
                    FullName = g.FullName,
                    Balance = g.Balance,
                    RegistrationDate = g.RegistrationDate,
                    BetSum = c.Sum(x => x.Sum)

                });

                var gamerBetTrans = gamerBet.GroupJoin(db.Transactions, t => t.Id, gb => gb.GamerId, (t, gb) => new
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Balance = t.Balance,
                    RegistrationDate = t.RegistrationDate,
                    BetSum = t.BetSum,
                    TransSum = gb.Sum(x => x.Sum),
                });

                //reportR.gamerR = gamerBetTrans.ToListAsync();

                //var gamerL = gamer.ToList();
                ////сумма внесений
                //     var Trans = db.Transactions.Where(p => p.TypeOperation == 0)
                //         .GroupBy(g => g.GamerId)
                //           .Select(p => new Transaction
                //           {
                //               GamerId = p.Key,
                //               Sum = p.Sum(x => x.Sum)
                //           });
                //     //сумма ставок

                //     var listSum = Trans.ToList();
            }
            else
            {
                //reportR.gamerR = gamer.ToListAsync();
            };




            return View("Report", reportR);
        }

        //в запросе использовать AsNoTracking()
    }
}
