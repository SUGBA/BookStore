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
        [HttpGet("GetLoginView")]
        public IActionResult GetLoginView(string Login = "", string Password = "")
        {
            var res = _service.CreateViewModel(Login, Password);
            return View("LoginPage", res);
        }

        ///// <summary>
        ///// Получение страницы авторизации по существующей модели
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("GetLoginView")]
        //public IActionResult GetLoginView(string Login = "", string Password = "")
        //{
        //    return View("LoginPage");
        //}

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
                return Redirect("/Admin/GetUsersEditView");
            else
                return RedirectToAction("GetUsersEditView", model);
        }
    }
}
