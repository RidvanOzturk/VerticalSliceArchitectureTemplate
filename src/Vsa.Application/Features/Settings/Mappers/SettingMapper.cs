using Vsa.Application.Features.Settings.Models;
using Vsa.Domain.Database;

namespace Vsa.Application.Features.Settings.Mappers;

public static class SettingMapper
{
    public static Setting ToEntity(SettingInsertRequest request) => new()
    {
        Key = request.Key,
        Value = request.Value
    };

    public static SettingReadResponse ToResponse(Setting setting) => new()
    {
        Key = setting.Key,
        Value = setting.Value
    };
}
