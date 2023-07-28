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
            var gamer = db.Gamers.Where(p => p.Status == Status).Select( t=> new ReportGamer
            {
                Id = t.Id,
                FullName = t.FullName,
                Balance = t.Balance,
                RegistrationDate = t.RegistrationDate

            }).AsNoTracking().ToList();
            //Условие ставок больше чем пополнений
            if (SelectionChecked == true)
            {
                var gamerBet = gamer.GroupJoin(db.Bets, g => g.Id, b => b.GamerId, (g, c) => new
                {
                    Id = g.Id,
                    FullName = g.FullName,
                    Balance = g.Balance,
                    RegistrationDate = g.RegistrationDate,
                    BetSum = c.Sum(x => x.Sum)

                }).ToList();

                var gamerBetTrans = gamerBet.GroupJoin(db.Transactions, t => t.Id, gb => gb.GamerId, (t, gb) => new ReportGamer
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Balance = t.Balance,
                    RegistrationDate = t.RegistrationDate,
                    BetSum = t.BetSum,
                    TransSum = gb.Sum(x => x.Sum),
                }).Where(z => z.BetSum >= z.TransSum);

                reportR.gamerR = gamerBetTrans.ToList();

            }
            else
            {
                reportR.gamerR = gamer.ToList();
            };

            return View("Report", reportR);
        }
    }
}
