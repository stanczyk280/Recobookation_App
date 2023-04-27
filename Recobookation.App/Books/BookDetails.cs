using MediatR;
using Recobookation.Domain;
using Recobookation.Persistence;

namespace Recobookation.App.Books
{
    public static class BookDetails
    {
        public class Query : IRequest<Book>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Book>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Book> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Books.FindAsync(request.Id);
            }
        }
    }
}