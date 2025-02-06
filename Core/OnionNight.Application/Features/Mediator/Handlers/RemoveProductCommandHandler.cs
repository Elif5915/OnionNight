using MediatR;
using OnionNight.Application.Features.Mediator.Commands;
using OnionNight.Persistence.Context;

namespace OnionNight.Application.Features.Mediator.Handlers;
public class RemoveProductCommandHandler : IRequest<RemoveProductCommand>
{
    private readonly OnionContext _context;

    public RemoveProductCommandHandler(OnionContext context)
    {
        _context = context;
    }
    public async Task Handle(RemoveProductCommand command, CancellationToken cancellationToken)
    {
        var value = await _context.Products.FindAsync(command.ProductId);
        _context.Products.Remove(value);
        await _context.SaveChangesAsync();
    }
}

