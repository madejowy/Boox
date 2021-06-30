using Boox.Models;
using Boox.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boox.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly BooxContext _context;
        private readonly ILogger<BookController> _logger;

        public BookController(
             BooxContext context,
             ILogger<BookController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult BooksToRead(string searchPhrase)
        {
            IQueryable<Book> books = _context.Books.Where(x => x.UserName == User.Identity.Name).Where(x=>x.IsReaded == false);

            //if (!string.IsNullOrWhiteSpace(searchPhrase))
            //{
            //    employees = employees.Where(x => x.LastName.Contains(searchPhrase) || x.City.Contains(searchPhrase));
            //}

            var vm = new BooksViewModel
            {
                Books = books.ToArray()
            };
            return View(vm);
        }

        public IActionResult ReadedBooks(string searchPhrase)
        {
            IQueryable<Book> books = _context.Books.Where(x => x.UserName == User.Identity.Name).Where(x => x.IsReaded == true);

            //if (!string.IsNullOrWhiteSpace(searchPhrase))
            //{
            //    employees = employees.Where(x => x.LastName.Contains(searchPhrase) || x.City.Contains(searchPhrase));
            //}

            var vm = new BooksViewModel
            {
                Books = books.ToArray()
            };
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookViewModel viewModel)
        {

            await _context.Books.AddAsync(new Book
            {
                UserName = @User.Identity.Name,
                Author = viewModel.Author,
                Title = viewModel.Title,
                NumberOfPages = viewModel.NumberOfPages,
                IsReaded = false,
                Rating = 1
            }); ;
            
            await _context.SaveChangesAsync();

            return RedirectToAction("BooksToRead");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

            return View(new EditBookViewModel
            {
                Author = data.Author,
                Title = data.Title,
                NumberOfPages = data.NumberOfPages               
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBookViewModel viewModel)
        {
            var data = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

            data.Author = viewModel.Author;
            data.Title = viewModel.Title;
            data.NumberOfPages = viewModel.NumberOfPages;

            await _context.SaveChangesAsync();

            return RedirectToAction("BooksToRead");
        }
        public IActionResult Delete(int id)
        {
            return View(new DeleteBookViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteBookViewModel viewModel)
        {
            var data = await _context.Books.FirstOrDefaultAsync(x => x.BookId == viewModel.BookId);

            if (data is null)
                return View(new DeleteBookViewModel(viewModel.BookId, "user does not exist"));

            _context.Books.Remove(data);

            await _context.SaveChangesAsync();

            return RedirectToAction("BooksToRead");
        }

        public async Task<IActionResult> Rate(int id)
        {
            var data = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

            return View(new RateBookViewModel
            {
                Author = data.Author,
                Title = data.Title,
                Rating = data.Rating
            });
        }

        [HttpPost]
        public async Task<IActionResult> Rate(int id, RateBookViewModel viewModel)
        {
            var data = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

            data.Rating = viewModel.Rating;

            await _context.SaveChangesAsync();

            return RedirectToAction("ReadedBooks");
        }

        public async Task<IActionResult> ReadedBook(int id)
        {
            var readedBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == id);

            readedBook.IsReaded = true;

            await _context.SaveChangesAsync();
            return RedirectToAction("ReadedBooks");
        }
    }
}
