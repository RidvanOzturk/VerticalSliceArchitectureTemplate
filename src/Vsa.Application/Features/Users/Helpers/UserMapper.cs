using Vsa.Application.Common.Models;
using Vsa.Application.Features.Users.Models;
using Vsa.Domain.Database;
using Vsa.Infra.Models.Contracts;

namespace Vsa.Application.Features.Users.Helpers;

public class UserMapper : IStatefulMapper
{
    public User Map(UserCreationRequest value)
    {
        return new User()
        {
            Name = value.Name
        };
    }

    public IdResponse MapToIdResponse(User value)
    {
        return new IdResponse(value.Id);
    }

    public UserFetchingResponse MapToFullTypeResponse(User value)
    {
        return new UserFetchingResponse(value.Id,
                                        value.Name);
    }
}
