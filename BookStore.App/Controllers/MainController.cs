using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Data.EntityDto.MainDto;
using BookStore.Data.EntityDto.NewsDto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>

    [Route("Main")]
    public class MainController : Controller
    {
        private readonly IMainService _service;

        public MainController(IMainService service)
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
            List<MainDto> res = await _service.CreateViewModel();
            return View("MainPage", res);
        }
    }
}
