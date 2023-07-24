using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class ReportController : Controller
    {

        public IActionResult Index()
        {
            return View("Report");
        }

        public async Task<IActionResult> CreateReport()
        {
            return View();
        }
    }
}
