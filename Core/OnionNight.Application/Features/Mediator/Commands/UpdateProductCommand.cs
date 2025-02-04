using MediatR;

namespace OnionNight.Application.Features.Mediator.Commands;
public class UpdateProductCommand : IRequest
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductStock { get; set; }
    public decimal ProductPrice { get; set; }
}

