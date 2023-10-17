using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер страницы авторизации
    /// </summary>

    [Route("Login")]
    public class LoginController : Controller
    {
        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetView")]
        public async Task<IActionResult> GetView()
        {
            return View("LoginPage");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login()
        {
            throw new NotImplementedException();
        }
    }
}
