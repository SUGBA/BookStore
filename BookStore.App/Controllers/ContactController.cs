using BookStore.App.Services;
using BookStore.App.Services.ContollerServices.Interfaces;
using BookStore.Data.EntityDto.ContactDto;
using BookStore.Data.EntityDto.MainDto;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    /// <summary>
    /// Контроллер страницы с контактами
    /// </summary>

    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
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
            List<ContactDto> res = await _service.CreateViewModel();
            return View("ContactPage", res);
        }
    }
}
