﻿using AutoMapper;
using MediatR;
using Recobookation.Domain;
using Recobookation.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recobookation.App.Books
{
    public static class BookEdit
    {
        public class Command : IRequest
        {
            public Book Book { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var book = await _context.Books.FindAsync(request.Book.Id);

                _mapper.Map(request.Book, book);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}