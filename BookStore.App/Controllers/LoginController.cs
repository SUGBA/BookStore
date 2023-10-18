using BookStore.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер страницы авторизации
    /// </summary>

    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }


        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetView")]
        public IActionResult GetView()
        {
            var res = _service.CreateViewModel();
            return View("LoginPage", res);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            throw new NotImplementedException();
        }
    }
}
