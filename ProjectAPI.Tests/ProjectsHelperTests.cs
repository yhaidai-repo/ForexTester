using Application.Helpers;
using Domain.Models;

namespace ProjectAPI.Tests;

public class ProjectsHelperTests
{
    [Fact]
    public void ReturnsTop3_OrderedByUsesDesc()
    {
        List<Indicator> indicators =
        [
            new() { Name = "RSI", Parameters = "a=1;b=2;c=3" },
            new() { Name = "RSI", Parameters = "x=5;y=7" },
            new() { Name = "RSI", Parameters = "x=1;y=8" },
            new() { Name = "MA", Parameters = "length=10" },
            new() { Name = "MA", Parameters = "" },
            new() { Name = "BB", Parameters = "stddev=2" }
        ];

        var result = ProjectsHelper.GetTop3Indicators(indicators);

        Assert.Equal(3, result.Count);
        Assert.Equal("RSI", result[0].Name);
        Assert.Equal(3, result[0].Uses);
        Assert.Equal("MA", result[1].Name);
        Assert.Equal(2, result[1].Uses);
        Assert.Equal("BB", result[2].Name);
    }

    [Fact]
    public void ReturnsLessThan3_WhenInputHasFewerDistinctNames()
    {
        List<Indicator> indicators =
        [
            new() { Name = "MA", Parameters = "length=10" },
            new() { Name = "MA", Parameters = "" }
        ];

        var result = ProjectsHelper.GetTop3Indicators(indicators);

        Assert.Single(result);
        Assert.Equal("MA", result[0].Name);
        Assert.Equal(2, result[0].Uses);
    }

    [Fact]
    public void ReturnsEmptyList_WhenInputIsEmpty()
    {
        var result = ProjectsHelper.GetTop3Indicators([]);

        Assert.Empty(result);
    }

    [Fact]
    public void GroupsByName_WithCaseInsensitivity()
    {
        List<Indicator> indicators =
        [
            new() { Name = "MA", Parameters = "length=10" },
            new() { Name = "ma", Parameters = "" }
        ];

        var result = ProjectsHelper.GetTop3Indicators(indicators);

        Assert.Single(result);
        Assert.Equal(2, result[0].Uses);
    }
}
