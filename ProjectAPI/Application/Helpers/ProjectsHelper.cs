using Domain.Models;

namespace Application.Helpers;

public static class ProjectsHelper
{
    public static List<IndicatorRate> GetTop3Indicators(List<Indicator> indicators)
        => [.. indicators
                .GroupBy(x => x.Name, StringComparer.OrdinalIgnoreCase)
                .Select(x => new IndicatorRate(x.Key, x.Count()))
                .OrderByDescending(x => x.Uses)
                .Take(3)
           ];
}
