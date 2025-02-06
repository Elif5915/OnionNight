using MediatR;
using OnionNight.Application.Features.Mediator.Commands;
using OnionNight.Domain.Entities;
using OnionNight.Persistence.Context;

namespace OnionNight.Application.Features.Mediator.Handlers;
public class CreateProductCommandHandler : IRequest<CreateProductCommand>
{
    private readonly OnionContext _context;

    public CreateProductCommandHandler(OnionContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        _context.Products.Add(new Product
        {
            ProductName = command.ProductName,
            ProductPrice = command.ProductPrice,
            ProductStock = command.ProductStock

        });
        await _context.SaveChangesAsync();
    }
}

