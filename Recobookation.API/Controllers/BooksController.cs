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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, Book book)
        {
            book.Id = id;
            return Ok(await Mediator.Send(new BookEdit.Command { Book = book }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            return Ok(await Mediator.Send(new BookDelete.Command { Id = id }));
        }
    }
}