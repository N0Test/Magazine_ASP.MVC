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
        private readonly NewsService _service;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _service = new NewsService();
        }

        public IActionResult Index()
        {
            var model = new TopNewsViewModel
            {
                LastestNews = _service.GetLastestNews(4),
                TopNews = _service.GetTopNews(4)
            };
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