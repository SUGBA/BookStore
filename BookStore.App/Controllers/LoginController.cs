using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [HttpGet("GetView")]
        public IActionResult GetView()
        {
            return View();
        }
    }
}
