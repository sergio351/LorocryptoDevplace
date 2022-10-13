using lorodevplace.Models;
using lorodevplace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace lorodevplace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConsumeApiUser _service;

        public HomeController(ILogger<HomeController> logger, IConsumeApiUser service)
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

        public async Task<IActionResult> RegisterPost(UserRegisterDto usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.Register(usuario);
                    return RedirectToAction("Billetera", "Home");
                }
                else
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}