using System.ComponentModel.DataAnnotations;
using static TestWebApp.Models.Gamer;

namespace TestWebApp.Models
{
    public class ReportModel
    {
        
        public List<ReportGamer> gamerR { get; set; }

        public bool? Selection { get; set; } = false;

        public EnumStatus Status { get; set; }
    }
}
