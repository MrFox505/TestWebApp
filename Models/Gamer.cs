using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class Gamer
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }//переделать на 3 поля и сделать собираемое скрытое
        public int Balance { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public EnumStatus Status { get; set; }
        public enum EnumStatus { Новый, Плохой }
    }
}
