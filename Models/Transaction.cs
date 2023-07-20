using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int GamerId { get; set; }
        public int Sum { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public EnumTypeOperation TypeOperation { get; set; }
        public enum EnumTypeOperation {[Display(Name = "Пополнение")] Пополнение, [Display(Name = "Снятие")] Снятие }
    }
}
