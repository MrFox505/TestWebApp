namespace TestWebApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int GamerId { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string TypeOperation { get; set; }
    }
}
