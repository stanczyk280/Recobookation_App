using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recobookation.App.Books;
using Recobookation.Domain;
using Recobookation.Persistence;

namespace Recobookation.API.Controllers
{
    public class BooksController : BaseApiController
    {
        //api/books
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return await Mediator.Send(new BookList.Query());
        }

        //api/books/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            return await Mediator.Send(new BookDetails.Query { Id = id });
        }

        //api/books/
        [HttpPost]
        public async Task<IActionResult> PostBook(Book book)
        {
            return Ok(await Mediator.Send(new BookCreate.Command { Book = book }));
        }
    }
}