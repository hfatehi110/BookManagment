using BookManagment.Application.Interfaces;
using BookManagment.Application.Services.People.Command.InsertPeople;
using BookManagment.Application.Services.People.Query;
using Microsoft.AspNetCore.Mvc;

namespace BookManagment.WebView.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IRequestHandler<PeopleItemCommand,int> _InsertPeopleHandler;
        private readonly IRequestHandler<int,bool> _DeletePeopleHandler;
        private readonly IRequestHandler<GetAllPeopleItem> _GetAllPeopleHandler;

        public PeopleController(IRequestHandler<PeopleItemCommand, int> insertPeopleHandler, IRequestHandler<GetAllPeopleItem> getAllPeopleHandler, IRequestHandler<int, bool> deletePeopleHandler)
        {
            _InsertPeopleHandler = insertPeopleHandler;
            _GetAllPeopleHandler = getAllPeopleHandler;
            _DeletePeopleHandler = deletePeopleHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_GetAllPeopleHandler.Handler(CancellationToken.None));
        }

        [HttpPost]
        public async Task<int> Insert(PeopleItemCommand peopleItem)
        {
            return await _InsertPeopleHandler.Handler(peopleItem, CancellationToken.None);           
        }
        [HttpDelete]
        public async Task<bool> Delete(int PersonId)
        {
            return await _DeletePeopleHandler.Handler(PersonId, CancellationToken.None);
        }
    }
}
