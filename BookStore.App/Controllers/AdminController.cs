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
        /// Получение страницы редактирования пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsersEditView")]
        [Authorize]
        public IActionResult GetUsersEditView()
        {
            return View("AdminUsersPage");
        }

        /// <summary>
        /// Получение страницы редактированя каталога
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCatalogEditView")]
        [Authorize]
        public IActionResult GetCatalogEditView()
        {
            return View("AdminCatalogPage");
        }

        /// <summary>
        /// Получение страницы редактированя новостей
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNewsEditView")]
        [Authorize]
        public IActionResult GetNewsEditView()
        {
            return View("AdminNewsPage");
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
    }
}
