using FunTranslation.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;

namespace FunTranslation.Presentation.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            
            
                string baslik = "<p><b><i>Veysel Uğur KIZMAZ</i></b></p>";
                string htmlBaslik = HttpUtility.HtmlEncode(baslik);
                string htmlBaslik2 = HttpUtility.HtmlDecode(htmlBaslik);
                ViewBag.Baslik = baslik;
                ViewBag.HtmlBaslik = htmlBaslik;
                ViewBag.HtmlBaslik2 = htmlBaslik2;
                return View();
            
            
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }
    }
}