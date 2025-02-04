using MediatR;

namespace OnionNight.Application.Features.Mediator.Commands;
public class RemoveProductCommand : IRequest
{
    public int ProductId { get; set; }
    public RemoveProductCommand(int productId)
    {
        ProductId = productId;
    }
}

