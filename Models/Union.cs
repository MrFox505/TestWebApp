﻿namespace TestWebApp.Models
{
    public class Union
    {
        public IEnumerable<Gamer> gamerU { get; set; }
        public IEnumerable<Transaction> transactionU { get; set; }
        public IEnumerable<Bet> betU { get; set; }

    }
}
