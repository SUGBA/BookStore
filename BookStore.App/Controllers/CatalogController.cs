using BookStore.App.Services.ContollerServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Contollers
{
    /// <summary>
    /// Контроллер страницы с каталогом
    /// </summary>

    [Route("Catalog")]
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;

        public CatalogController(ICatalogService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetView")]
        public async Task<IActionResult> GetView()
        {
            var res = await _service.CreateViewModel();
            return View("CatalogPage", res);
        }
    }
}
