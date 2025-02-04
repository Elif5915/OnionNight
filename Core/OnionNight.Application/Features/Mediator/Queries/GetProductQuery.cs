using MediatR;
using OnionNight.Application.Features.Mediator.Results;

namespace OnionNight.Application.Features.Mediator.Queries;
public class GetProductQuery : IRequest<List<GetProductQueryResult>>
{
    // istekler buraya yapılacak. IRequest miras alan yerde istek yapılır.
}
