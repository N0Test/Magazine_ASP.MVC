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

        public IActionResult Details(int id)
        {
            var model = _service.GetDetailsNews(id);
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

        public IActionResult Create()
        {
            return View(new NewsModel());
        }

        [HttpPost]
        public IActionResult Create([FromForm] NewsModel model)
        {
            var newNews = _service.CreateOrUpdate(model);

            if (newNews != null)
            {
                return RedirectToAction("Index", new { id = newNews.Id });
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var news = _service.GetNewsById(id);

            if (news == null) return NotFound();

            return View(news);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromForm] NewsModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Перевірте правильність внесених даних");

                return View(model);
            }

            var newNews = _service.CreateOrUpdate(model);

            if (newNews != null)
            {
                return RedirectToAction("Index", new { id });
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var news = _service.GetNewsById(id);

            if (news == null) return NotFound();

            return View(news);
        }

        [HttpPost]
        public ActionResult Delete(int id, NewsModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}