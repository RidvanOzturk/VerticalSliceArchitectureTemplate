using FastEndpoints;

namespace Vsa.Application.Features.Settings.Models;

public class SettingsQueryRequest
{
    [QueryParam]
    public string Key { get; set; } = string.Empty;

    [QueryParam]
    public string Value { get; set; } = string.Empty;
}
