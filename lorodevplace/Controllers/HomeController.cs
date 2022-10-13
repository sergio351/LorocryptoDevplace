using lorodevplace.Models;
using lorodevplace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lorodevplace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConsumeUserService _service;

        public HomeController(ILogger<HomeController> logger, IConsumeUserService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> LoginPost(UserLoginDto usuario)
        {
            var result = await _service.Login(usuario);
            if (result == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("Billetera", "Home");
            }
        }

        public IActionResult Billetera()
        {
            return View();
        }

        public IActionResult Registro()
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