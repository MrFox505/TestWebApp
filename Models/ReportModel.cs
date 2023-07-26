using System.ComponentModel.DataAnnotations;
using static TestWebApp.Models.Gamer;

namespace TestWebApp.Models
{
    public class ReportModel
    {
        [Key]
        public IEnumerable<Gamer> gamerR { get; set; }

        public bool Selecion { get; set; }

        public EnumStatus Status { get; set; }
    }
}
