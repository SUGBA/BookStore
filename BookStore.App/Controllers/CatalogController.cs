using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Contollers
{
    [Route("Catalog")]
    public class CatalogController : Controller
    {
        [HttpGet("GetView")]
        public IActionResult GetView()
        {
            return View();
        }
    }
}
