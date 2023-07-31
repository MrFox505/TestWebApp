using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public class ReportGamer: Gamer
    {       
        public int BetSum { get; set; }
        public int TransSum { get; set; }
    }
}
