using MediatR;
using Microsoft.EntityFrameworkCore;
using Recobookation.Domain;
using Recobookation.Persistence;

namespace Recobookation.App.Books
{
    public static class BookList
    {
        public class Query : IRequest<List<Book>>
        { }

        public class Handler : IRequestHandler<Query, List<Book>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Book>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Books.ToListAsync();
            }
        }
    }
}