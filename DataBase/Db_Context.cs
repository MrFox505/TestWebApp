using TestWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace TestWebApp.DataBase
{
    public class Db_Context : DbContext
    {
        public DbSet<Gamer> Gamers => Set<Gamer>();//представляет набор объектов, которые хранятся в базе данных
        public DbSet<Transaction> Transactions => Set<Transaction>();//представляет набор объектов, которые хранятся в базе данных
        public DbSet<Bet> Bets => Set<Bet>();//представляет набор объектов, которые хранятся в базе данных
   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//устанавливает параметры подключения
        {
            optionsBuilder.UseSqlite("Data Source=TestAppSQLite.db");//определяем тип базы и строку подключения
        }
    }
}