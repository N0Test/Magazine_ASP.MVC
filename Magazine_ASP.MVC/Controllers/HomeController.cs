using Magazine_ASP.MVC.Models;
using Magazine_ASP.MVC.Services;
using Magazine_ASP.MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Magazine_ASP.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomePageNewsService _service;

        public HomeController(ILogger<HomeController> logger, IHomePageNewsService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index([FromQuery] string q)
        {
            ViewData["SearchQuery"] = q;

            var model = _service.GetHomePageNewsViewModel(4, 20, DateTime.Now.AddDays(-5));
            return View(model);
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