using Certificates2024.Data.Services;
using Certificates2024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Certificates2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICertificateTopicsService _certificateTopicsService;

        public HomeController(ILogger<HomeController> logger, ICertificateTopicsService certificateTopicsService)
        {
            _logger = logger;
            _certificateTopicsService = certificateTopicsService;
        }

        public async Task<IActionResult> Index()
        {
            var topics = await _certificateTopicsService.GetAllAsync();
            return View(topics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
