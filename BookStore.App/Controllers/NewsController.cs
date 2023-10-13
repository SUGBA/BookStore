using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Controllers
{
    [Route("News")]
    public class NewsController : Controller
    {
        [HttpGet("GetView")]
        public IActionResult GetView()
        {
            return View();
        }
    }
}
