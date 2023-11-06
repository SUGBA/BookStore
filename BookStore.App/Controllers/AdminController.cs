using BookStore.Admin.Dto;
using BookStore.App.Services.ContollerServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        [HttpGet("Route")]
        public IActionResult Route()
        {
            var userCoockie = HttpContext.User.Identity;
            if (userCoockie is not null && userCoockie.IsAuthenticated)
                return RedirectToAction("GetUsersEditView", "Admin");
            else
                return RedirectToAction("GetLoginView", "Admin");
        }

        /// <summary>
        /// Получение страницы авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetLoginView/{Login?}/{Password?}/{Message?}")]
        public IActionResult GetLoginView(string Login = "", string Password = "", string Message = "")
        {
            var res = _service.CreateViewModel(Login, Password, Message);
            return View("LoginPage", res);
        }

        /// <summary>
        /// Авторизация
        /// </summary>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto model)
        {
            if (await _service.Login(model, HttpContext))
                return RedirectToAction("GetUsersEditView", "Admin");
            else
                return RedirectToAction("GetLoginView", "Admin",
                    new { Login = model.Login, Password = model.Password, Message = model.Message });
        }

        /// <summary>
        /// Получение страницы редактирования пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsersEditView")]
        [Authorize]
        public async Task<IActionResult> GetUsersEditView()
        {
            var res = await _service.UserViewModel(HttpContext);
            return View("AdminUsersPage", res);
        }

        /// <summary>
        /// Получение страницы редактированя каталога
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCatalogEditView")]
        [Authorize]
        public async Task<IActionResult> GetCatalogEditView()
        {
            var res = await _service.CatalogViewModel(HttpContext);
            return View("AdminCatalogPage", res);
        }

        /// <summary>
        /// Получение страницы редактированя новостей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNewsEditView")]
        [Authorize]
        public async Task<IActionResult> GetNewsEditView()
        {
            var res = await _service.NewsViewModel(HttpContext);
            return View("AdminNewsPage", res);
        }

        /// <summary>
        /// Выбран пользователь
        /// </summary>
        /// <param name="type"> Тип раздела </param>
        /// <param name="itemId"> id элемента </param>
        /// <returns></returns>
        [HttpGet("SelectingUserElement/{itemId}")]
        [Authorize]
        public async Task<IActionResult> SelectingUserElement(int itemId)
        {
            var res = await _service.UserViewModel(HttpContext, itemId);
            return View("AdminUsersPage", res);
        }

        /// <summary>
        /// Выбрана книга
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("SelectingCatalogElement/{departmentId}/{bookId}")]
        [Authorize]
        public async Task<IActionResult> SelectingCatalogElement(int itemId)
        {
            var res = await _service.CatalogViewModel(HttpContext, itemId);
            return View("AdminCatalogPage", res);
        }

        /// <summary>
        /// Выбрана новость
        /// </summary>
        /// <param name="type"> Тип раздела </param>
        /// <param name="itemId"> id элемента </param>
        /// <returns></returns>
        [HttpGet("SelectingNewsElement/{itemId}")]
        [Authorize]
        public async Task<IActionResult> SelectingNewsElement(int itemId)
        {
            var res = await _service.NewsViewModel(HttpContext, itemId);
            return View("AdminNewsPage", res);
        }
    }
}
