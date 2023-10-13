using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Contollers
{
    /// <summary>
    /// Контроллер страницы с каталогом
    /// </summary>

    [Route("Catalog")]
    public class CatalogController : Controller
    {
        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetView")]
        public IActionResult GetView()
        {
            return View();
        }
    }
}
