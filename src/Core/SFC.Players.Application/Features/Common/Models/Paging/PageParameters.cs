﻿using SFC.Players.Application.Features.Common.Models.Filters;
using SFC.Players.Application.Features.Common.Models.Sorting;

namespace SFC.Players.Application.Features.Common.Models.Paging;
public class PageParameters<T>
{
    public Filters<T> Filters { get; set; } = default!;

    public Sortings<T> Sorting { get; set; } = default!;

    public Pagination Pagination { get; set; } = default!;
}
