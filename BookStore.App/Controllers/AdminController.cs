using BookStore.App.Services.ContollerServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер страницы авторизации
    /// </summary>

    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _service;

        public AdminController(IAdminService service)
        {
            _service = service;
        }

        /// <summary>
        /// Получение страницы авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLoginView")]
        public IActionResult GetLoginView()
        {
            var res = _service.CreateViewModel();
            return View("LoginPage", res);
        }

        /// <summary>
        /// Получение страницы редактирования пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsersEditView")]
        public IActionResult GetUsersEditView()
        {
            return View("AdminUsersPage");
        }

        /// <summary>
        /// Получение страницы редактированя каталога
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCatalogEditView")]
        public IActionResult GetCatalogEditView()
        {
            return View("AdminCatalogPage");
        }

        /// <summary>
        /// Получение страницы редактированя новостей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNewsEditView")]
        public IActionResult GetNewsEditView()
        {
            return View("AdminNewsPage");
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        [HttpPost("Login")]
        public IActionResult Login()
        {
            return View("AdminUsersPage");
        }
    }
}
