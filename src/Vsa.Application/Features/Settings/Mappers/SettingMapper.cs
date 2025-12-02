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
        Id = setting.Id,
        Key = setting.Key,
        Value = setting.Value
    };

    public static void UpdateEntity(SettingUpdateRequest request, Setting setting)
    {
        setting.Value = request.Value;
        setting.Key = request.Key;
    }
}
