﻿using SFC.Players.Application.Features.Common.Models.Paging;
using SFC.Players.Application.Interfaces.Common;
using SFC.Players.Infrastructure.Services;

namespace SFC.Players.Infrastructure.UnitTests.Services;
public class UriServiceTests
{
    [Fact]
    [Trait("Service", "Uri")]
    public void Service_Uri_ShouldReturnUri()
    {
        // Arrange
        IUriService service = new UriService("https://localhost:7366");

        // Act
        Uri result = service.GetPageUri(
            "?Pagination.Page=1&Pagination.Size=10&Sorting[0].Name=Height&Sorting[0].Direction=Descending",
            "/api/Players/byfilters", 4
        );

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("Service", "Uri")]
    public void Service_Uri_ShouldSetNewPageValueInQueryString()
    {
        // Arrange
        IUriService service = new UriService("https://localhost:7366");

        // Act
        Uri result = service.GetPageUri(
            "?Pagination.Page=1&Pagination.Size=10&Sorting[0].Name=Height&Sorting[0].Direction=Descending",
            "/api/Players/byfilters", 4
        );

        // Assert
        Assert.Contains("Pagination.Page=4", result.Query);
        Assert.DoesNotContain("Pagination.Page=1", result.Query);
    }

    [Fact]
    [Trait("Service", "Uri")]
    public void Service_Uri_ShouldNotSetNewPageValueInQueryString()
    {
        // Arrange
        IUriService service = new UriService("https://localhost:7366");

        // Act
        Uri result = service.GetPageUri(
            "?Pagination.Size=10&Sorting[0].Name=Height&Sorting[0].Direction=Descending",
            "/api/Players/byfilters", 4
        );

        // Assert
        Assert.DoesNotContain("Pagination.Page=4", result.Query);
        Assert.DoesNotContain("Pagination.Page=1", result.Query);
    }
}
