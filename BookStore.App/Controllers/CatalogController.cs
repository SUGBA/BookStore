using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Data.EntityDto.CatalogDto;
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

        /// <summary>
        /// Отсортировать
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("Sort")]
        public async Task<IActionResult> Sort(SortPropertyDto model)
        {
            var res = await _service.CreateViewModel(model);
            return View("CatalogPage", res);
        }
    }
}
