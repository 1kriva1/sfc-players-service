﻿namespace SFC.Players.Application.Features.Common.Dto;
public class RangeLimitDto<T>
{
    public T? From { get; set; }

    public T? To { get; set; }
}
