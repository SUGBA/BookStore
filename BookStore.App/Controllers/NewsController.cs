using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер страницы с новостями
    /// </summary>
    
    [Route("News")]
    public class NewsController : Controller
    {
        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetView")]
        public async Task<IActionResult> GetView()
        {
            return View("NewsPage");
        }
    }
}
