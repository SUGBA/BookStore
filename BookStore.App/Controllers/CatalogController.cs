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
        public async Task<IActionResult> GetView()
        {
            return View("CatalogPage");
        }

        /// <summary>
        /// Отсортировать
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("Sort")]
        public async Task<IActionResult> Sort()
        {
            throw new NotImplementedException();
        }
    }
}
