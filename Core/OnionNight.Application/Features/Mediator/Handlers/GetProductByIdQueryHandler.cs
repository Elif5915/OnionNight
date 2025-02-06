using MediatR;
using OnionNight.Application.Features.Mediator.Queries;
using OnionNight.Application.Features.Mediator.Results;
using OnionNight.Persistence.Context;

namespace OnionNight.Application.Features.Mediator.Handlers;
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
{
    private readonly OnionContext _context;

    public GetProductByIdQueryHandler(OnionContext context)
    {
        _context = context;
    }

    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Products.FindAsync(request.ProductId);
        return new GetProductByIdQueryResult
        {
            ProductId = values.ProductId,
            ProductName = values.ProductName,
            ProductPrice = values.ProductPrice,
            ProductStock = values.ProductStock
        };
    }
}

