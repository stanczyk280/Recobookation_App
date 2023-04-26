﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recobookation.Domain;
using Recobookation.Persistence;

namespace Recobookation.API.Controllers
{
    public class BookController : BaseApiController
    {
        private readonly DataContext context;

        public BookController(DataContext Context)
        {
            Context = context;
        }

        //api/books
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return await context.Books.ToListAsync();
        }

        //api/books/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            return await context.Books.FindAsync(id);
        }
    }
}