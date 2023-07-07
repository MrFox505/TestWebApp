using TestWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace TestWebApp.DataBase
{
    public class Db_Context : DbContext
    {

        //public DbSet<DogViewModel> Dogs { get; set; } = null!;
        //public Child_DbContext(DbContextOptions<Child_DbContext> options)
        //    : base(options)
        //{
        //    Database.EnsureCreated();   // создаем базу данных при первом обращении
        //}


        public DbSet<Gamer> Gamers => Set<Gamer>();//представляет набор объектов, которые хранятся в базе данных
        public DbSet<Transaction> Transactions => Set<Transaction>();//представляет набор объектов, которые хранятся в базе данных
        public DbSet<Bet> Bets => Set<Bet>();//представляет набор объектов, которые хранятся в базе данных
        //public DbSet<Bonus> Bonuses => Set<Bonus>();//представляет набор объектов, которые хранятся в базе данных

        //public DbSet<Gamer> Gamers { get; set; } = null!;
        //public DbSet<Transaction> Transactions { get; set; } = null!;
        //public Db_Context() => Database.EnsureCreated();//проверка наличия базы, если нет, то создаст автоматом

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//устанавливает параметры подключения
        {
            optionsBuilder.UseSqlite("Data Source=TestAppSQLite.db");//определяем тип базы и строку подключения
        }
    }
}