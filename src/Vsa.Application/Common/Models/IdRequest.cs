using FastEndpoints;

namespace Vsa.Application.Common.Models;

public class IdRequest
{
    [RouteParam]
    public int Id { get; set; }
}
