using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер страницы с контактами
    /// </summary>

    [Route("Contact")]
    public class ContactController : Controller
    {
        /// <summary>
        /// Получение страницы
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetView")]
        public IActionResult GetView()
        {
            return View("ContactPage");
        }
    }
}
