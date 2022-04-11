using Microsoft.AspNetCore.Mvc;

namespace BookManagment.WebView.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
