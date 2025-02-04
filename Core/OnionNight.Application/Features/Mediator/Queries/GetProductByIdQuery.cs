using MediatR;
using OnionNight.Application.Features.Mediator.Results;

namespace OnionNight.Application.Features.Mediator.Queries;
public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
{
    public int ProductId { get; set; }
    public GetProductByIdQuery(int productId)
    {
        ProductId = productId;
    }
}

