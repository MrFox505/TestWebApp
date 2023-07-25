using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult RedirectHomePage()
        {
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CreateTransaction()
        {
            var transVm = new Transaction();
            return View(transVm);
        }
        public async Task<IActionResult> CreateTransactionDB(Transaction transaction)
        {
            DataBase.Db_Context db = new DataBase.Db_Context();
            Gamer? gamer = await db.Gamers.FirstOrDefaultAsync(p => p.Id == transaction.GamerId);
            if (gamer != null)
            {
                if (transaction.TypeOperation == Transaction.EnumTypeOperation.Пополнение)
                {

                    gamer.Balance += transaction.Sum;
                    db.Gamers.Update(gamer);
                    await db.SaveChangesAsync();

                }
                else if (transaction.TypeOperation == Transaction.EnumTypeOperation.Снятие)
                {

                    gamer.Balance -= transaction.Sum;
                    db.Gamers.Update(gamer);
                    await db.SaveChangesAsync();

                }
                db.Transactions.Add(transaction);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("RedirectHomePage");
        }
        public async Task<IActionResult> EditTransaction(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                Transaction? transaction = await db.Transactions.FirstOrDefaultAsync(p => p.Id == id);
                if (transaction != null) return View(transaction);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditTransaction(Transaction transaction)
        {
            DataBase.Db_Context db = new DataBase.Db_Context();
            Gamer? gamer = await db.Gamers.FirstOrDefaultAsync(p => p.Id == transaction.GamerId);
            if (gamer != null)
            {
                if (transaction.TypeOperation == Transaction.EnumTypeOperation.Пополнение)
                {

                    gamer.Balance += transaction.Sum;
                    db.Gamers.Update(gamer);
                    await db.SaveChangesAsync();

                }
                else if (transaction.TypeOperation == Transaction.EnumTypeOperation.Снятие)
                {

                    gamer.Balance -= transaction.Sum;
                    db.Gamers.Update(gamer);
                    await db.SaveChangesAsync();

                }

                db.Transactions.Update(transaction);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("RedirectHomePage");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTransactionDB(int? id)
        {
            if (id != null)
            {
                DataBase.Db_Context db = new DataBase.Db_Context();
                Transaction? transaction = await db.Transactions.FirstOrDefaultAsync(p => p.Id == id);
                if (transaction != null)
                {
                    db.Transactions.Remove(transaction);
                    await db.SaveChangesAsync();
                    return RedirectToAction("RedirectHomePage");
                }
            }
            return NotFound();
        }
    }
}
