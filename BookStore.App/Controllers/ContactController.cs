using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        [HttpGet("GetView")]
        public IActionResult GetView()
        {
            return View();
        }
    }
}
