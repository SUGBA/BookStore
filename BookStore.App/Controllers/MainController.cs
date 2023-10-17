using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>

    [Route("Main")]
    public class MainController : Controller
    {
        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetView")]
        public async Task<IActionResult> GetView()
        {
            return View("MainPage");
        }
    }
}
