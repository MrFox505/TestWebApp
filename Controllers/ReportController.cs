using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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

        public async Task<IActionResult> NewCreateReport(EnumStatus Status, bool SelectionChecked)
        {
            Db_Context db = new Db_Context();
            ReportModel reportR = new ReportModel();

            //var gamerTemp = from p in (from gamers in db.Gamers
            //                           join bets in db.Bets on gamers.Id equals bets.GamerId
            //                           join trans in db.Transactions on gamers.Id equals trans.GamerId
            //                           where gamers.Status == Status & trans.TypeOperation == Transaction.EnumTypeOperation.Пополнение
            //                           //group gamers by gamers.Id into newGroup
            //                           select new ReportGamer
            //                           {
            //                               Id = gamers.Id,
            //                               FullName = gamers.FullName,
            //                               Balance = gamers.Balance,
            //                               RegistrationDate = gamers.RegistrationDate,
            //                               Status = gamers.Status,
            //                               BetSum = bets.Sum,
            //                               TransSum = trans.Sum
            //                           })
            //                group p by p.Id;


            //var gamer = gamerTemp.GroupBy(g => g.Id).Select(p => new
            //{
            //    Id = p.Key,
            //    All = p.Select(p => new ReportGamer
            //    {
            //        FullName = p.FullName,
            //        Balance = p.Balance,
            //        RegistrationDate = p.RegistrationDate,
            //        Status = p.Status,
            //        BetSum = Sum(x => x.BetSum),
            //        TransSum = trans.Sum
            //    })
            //});
            //игроки с нужным статусом
            var gamer = db.Gamers.GroupJoin(db.Bets, g => g.Id, b => b.GamerId, (g, c) => new ReportGamer
            {
                Id = g.Id,
                FullName = g.FullName,
                Balance = g.Balance,
                RegistrationDate = g.RegistrationDate,
                Status = g.Status,
                BetSum = c.Sum(x=>x.Sum)
            }).GroupJoin(db.Transactions, t => t.Id, gb => gb.GamerId, (t, gb) => new ReportGamer
            {
                Id = t.Id,
                FullName = t.FullName,
                Balance = t.Balance,
                RegistrationDate = t.RegistrationDate,
                Status = t.Status,
                BetSum = t.BetSum,
                TransSum = gb.Sum(x => x.Sum)
            }).Where(p => p.Status == Status).Select(l => new ReportGamer
            {
                Id = l.Id,
                FullName = l.FullName,
                Balance = l.Balance,
                RegistrationDate = l.RegistrationDate,
                Status = l.Status,
                BetSum = l.BetSum,
                TransSum = l.TransSum
            });

            reportR.gamerR = gamer.ToList();

            return View("Report", reportR);
        }

        public async Task<IActionResult> CreateReport(EnumStatus Status, bool SelectionChecked)
        {
            Db_Context db = new Db_Context();
            ReportModel reportR = new ReportModel();
            //игроки с нужным статусом
            var gamer = db.Gamers.Where(p => p.Status == Status).Select(t => new ReportGamer
            {
                Id = t.Id,
                FullName = t.FullName,
                Balance = t.Balance,
                RegistrationDate = t.RegistrationDate,
                Status = t.Status

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
                    Status = g.Status,
                    BetSum = c.Sum(x => x.Sum)

                }).ToList();

                var gamerBetTrans = gamerBet.GroupJoin(db.Transactions, t => t.Id, gb => gb.GamerId, (t, gb) => new ReportGamer
                {
                    Id = t.Id,
                    FullName = t.FullName,
                    Balance = t.Balance,
                    RegistrationDate = t.RegistrationDate,
                    Status = t.Status,
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
