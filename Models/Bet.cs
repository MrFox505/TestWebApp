namespace TestWebApp.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public int GamerId { get; set; }
        public int Sum { get; set; }
        public DateTime DateBet { get; set; }
        public float Win { get; set; }
        public DateTime CalculationDate { get; set; }
    }
}
