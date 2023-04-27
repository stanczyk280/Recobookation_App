using MediatR;
using Recobookation.Domain;
using Recobookation.Persistence;

namespace Recobookation.App.Books
{
    public static class BookCreate
    {
        public class Command : IRequest
        {
            public Book Book { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Books.Add(request.Book);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}