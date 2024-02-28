﻿using AutoMapper;

using SFC.Players.Application.Common.Mappings;
using SFC.Players.Application.Features.Players.Common.Dto;
using SFC.Players.Domain.Entities;

namespace SFC.Players.Application.Features.Players.Commands.Create;

public record CreatePlayerViewModel: IMapFrom<Player>
{
    public PlayerDto Player { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<Player, CreatePlayerViewModel>()
                                                   .ForMember(p => p.Player, d => d.MapFrom(z => z));
}
