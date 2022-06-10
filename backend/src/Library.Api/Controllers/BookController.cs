using Library.Api.Helpers;
using Library.Api.ViewModels;
using Library.Core.Interfaces.Services;
using Library.Core.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IResponseFormatter _responseFormatter;

        public BookController(IBookService bookService,
                              IResponseFormatter responseFormatter)
        {
            _bookService = bookService;
            _responseFormatter = responseFormatter;
        }

        [HttpGet]
        [Authorize]
        [Route("/api/books")]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books.Select(b => new BookViewModel()
            {
                Author = b.Author,
                Id = b.Id,
                Pages = b.Pages,
                Publisher = b.Publisher,
                Title = b.Title
            }));
        }

        [HttpPost]
        [Authorize]
        [Route("/api/books/{bookId:guid}/student/{studentEmail}")]
        public async Task<IActionResult> Post([FromRoute] BorrowRequest borrowRequest, [FromQuery] string action)
        {
            await _bookService.BorrowBookAsync(borrowRequest, action);
            return _responseFormatter.Format();
        }
    }
}
