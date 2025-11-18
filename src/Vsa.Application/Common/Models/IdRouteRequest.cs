using FastEndpoints;

namespace Vsa.Application.Common.Models;

public record IdRouteRequest
{
    [RouteParam]
    public int Id { get; init; }
}
