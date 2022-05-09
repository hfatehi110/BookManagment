using BookManagment.Application.Interfaces;
using BookManagment.Application.Services.Log.Query;
using Microsoft.AspNetCore.Mvc;

namespace BookManagment.WebView.Controllers
{
    public class LogController : Controller
    {
        private readonly IRequestHandler<GetAllLogQueryItem> _getAllLogQuery;

        public LogController(IRequestHandler<GetAllLogQueryItem> getAllLogQuery)
        {
            _getAllLogQuery = getAllLogQuery;
        }

        public IActionResult Index()
        {
            return View(_getAllLogQuery.Handler(CancellationToken.None));
        }
    }
}
