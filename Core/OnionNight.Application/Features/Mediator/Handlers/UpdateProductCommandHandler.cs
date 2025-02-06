using MediatR;
using OnionNight.Application.Features.Mediator.Commands;
using OnionNight.Persistence.Context;

namespace OnionNight.Application.Features.Mediator.Handlers;
public class UpdateProductCommandHandler : IRequest<UpdateProductCommand>
{
    private readonly OnionContext _context;

    public UpdateProductCommandHandler(OnionContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var value = await _context.Products.FindAsync(command.ProductId);
        value.ProductName = command.ProductName;
        value.ProductPrice = command.ProductPrice;
        value.ProductStock = command.ProductStock;
        await _context.SaveChangesAsync();
    }

}

