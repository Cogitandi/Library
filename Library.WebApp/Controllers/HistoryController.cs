using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core.Repositories;
using Library.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApp.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
        private readonly IBookActionRepository _bookActionRepository;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public HistoryController(IBookActionRepository bookActionRepository, UserManager<IdentityUser<Guid>> userManager)
        {
            _bookActionRepository = bookActionRepository;
            _userManager = userManager;
        }
        // GET : History/
        public async Task<IActionResult> Index()
        {
            var loggedUserId = _userManager.GetUserId(User);
            var actions = await _bookActionRepository.GetByUserId(Guid.Parse(loggedUserId));
            var model = actions.Select(x => new ActionViewModel()
            {
                ActionName = x.Name.Equals("Borrow")?"Wypożyczenie":"Zwrot",
                BookTitle = x.Book.Name,
                Date = x.Date,
            });
            return View(model);
        }
    }
}
