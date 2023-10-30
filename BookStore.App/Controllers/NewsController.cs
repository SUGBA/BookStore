using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Data.EntityDto.NewsDto;
using BookStore.EF.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер страницы с новостями
    /// </summary>

    [Route("News")]
    public class NewsController : Controller
    {
        private readonly INewsService _service;

        public NewsController(INewsService service)
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
            List<NewsDto> res = await _service.CreateViewModel();
            return View("NewsPage", res);
        }
    }
}
