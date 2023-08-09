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

        public async Task<IActionResult> CreateReport(EnumStatus Status, bool SelectionChecked)
        {
            Db_Context db = new Db_Context();
            ReportModel reportR = new ReportModel();

            //игроки с нужным статусом
            var gamer = db.Gamers.Where(p => p.Status == Status).Join(db.Bets, g => g.Id, b => b.GamerId, (g, c) => new ReportGamer//полчение ставок
            {
                Id = g.Id,
                FullName = g.FullName,
                Balance = g.Balance,
                RegistrationDate = g.RegistrationDate,
                Status = g.Status,
                BetSum = c.Sum
            }).GroupBy(l => l.Id).Select(cl => new ReportGamer//группировка и суммирование ставок
            {
                Id = cl.First().Id,
                FullName = cl.First().FullName,
                Balance = cl.First().Balance,
                RegistrationDate = cl.First().RegistrationDate,
                Status = cl.First().Status,
                BetSum = cl.Sum(x => x.BetSum)
            }).Join(db.Transactions.Where(k => k.TypeOperation == 0), t => t.Id, gb => gb.GamerId, (t, gb) => new ReportGamer//получение пополнений
            {
                Id = t.Id,
                FullName = t.FullName,
                Balance = t.Balance,
                RegistrationDate = t.RegistrationDate,
                Status = t.Status,
                BetSum = t.BetSum,
                TransSum = gb.Sum
            }).GroupBy(l => l.Id).Select(cl => new ReportGamer//группировка и суммирование пополнений
            {
                Id = cl.First().Id,
                FullName = cl.First().FullName,
                Balance = cl.First().Balance,
                RegistrationDate = cl.First().RegistrationDate,
                Status = cl.First().Status,
                BetSum = cl.First().BetSum,
                TransSum = cl.Sum(x => x.TransSum)
            }).AsQueryable().AsNoTracking();

            if (SelectionChecked)
            {
                var gamerSelection = gamer.Where(p => p.BetSum >= p.TransSum);
                reportR.gamerR = gamerSelection.ToList();
            }
            else
            {
                reportR.gamerR = gamer.ToList();
            }

            return View("Report", reportR);
        }
    }
}
