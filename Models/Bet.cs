using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        public int GamerId { get; set; }
        public int Sum { get; set; }
        public DateTime DateBet { get; set; } = DateTime.Now;
        public float Win { get; set; }
        public DateTime CalculationDate { get; set; } = DateTime.Now;
    }
}
