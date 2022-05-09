using Microsoft.AspNetCore.Mvc;

namespace BookManagment.WebView.Controllers
{
    public class BooksController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
