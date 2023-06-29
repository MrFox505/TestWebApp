﻿using TestWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TestWebApp.DataBase
{
    public class Child_DbContext : DbContext
    {

        //public DbSet<DogViewModel> Dogs { get; set; } = null!;
        //public Child_DbContext(DbContextOptions<Child_DbContext> options)
        //    : base(options)
        //{
        //    Database.EnsureCreated();   // создаем базу данных при первом обращении
        //}


        public DbSet<Gamer> Gamers => Set<Gamer>();//представляет набор объектов, которые хранятся в базе данных
        public DbSet<Transaction> Transactions => Set<Transaction>();//представляет набор объектов, которые хранятся в базе данных
        //public DbSet<Gamer> Gamers { get; set; } = null!;
        //public DbSet<Transaction> Transactions { get; set; } = null!;
        public Child_DbContext() => Database.EnsureCreated();//проверка наличия базы, если нет, то создаст автоматом

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//устанавливает параметры подключения
        {
            optionsBuilder.UseSqlite("Data Source=TestAppSQLite.db");//определяем тип базы и строку подключения
        }
    }
}