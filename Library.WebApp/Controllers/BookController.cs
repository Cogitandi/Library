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
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly UserManager<IdentityUser<Guid>> _userManager;

        public BookController(IBookRepository bookRepository, UserManager<IdentityUser<Guid>> userManager)
        {
            _bookRepository = bookRepository;
            _userManager = userManager;
        }
        // GET : Book/
        public async Task<IActionResult> Index()
        {
            var books = await _bookRepository.GetAll();
            var model = books.Select(x=> new BookViewModel()
            {
                Id = x.Id,
                Author = x.Author,
                Status = x.IsBorrowed == true?"Wypożyczona":"Dostępna",
                Name = x.Name,
                BorrowedUserId = x.GetBorrowedUserId()
            });
            return View(model);
        }
        // POST : Book/Borrow/{id}
        public async Task<IActionResult> Borrow(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            var book = await _bookRepository.GetById(id);
            if(!book.IsBorrowed)
            {
                book.Borrow(user);
                await _bookRepository.Update(book);
            }
            return RedirectToAction("Index");
        }
        // POST : Book/Return/{id}
        public async Task<IActionResult> Return(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            var book = await _bookRepository.GetById(id);
            if (book.IsBorrowed)
            {
                book.Return(user);
                await _bookRepository.Update(book);
            }
            return RedirectToAction("Index");
        }
    }
}
