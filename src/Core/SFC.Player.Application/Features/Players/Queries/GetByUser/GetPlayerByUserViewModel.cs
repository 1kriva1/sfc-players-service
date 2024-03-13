﻿using AutoMapper;

using SFC.Player.Application.Common.Mappings;
using SFC.Player.Application.Features.Player.Queries.GetByUser.Dto;
using SFC.Player.Domain.Entities;

using PlayerEntity = SFC.Player.Domain.Entities.Player;

namespace SFC.Player.Application.Features.Player.Queries.Get;

public record GetPlayerByUserViewModel : IMapFrom<PlayerEntity>
{
    public PlayerByUserDto Player { get; set; } = null!;

    public void Mapping(Profile profile) => profile.CreateMap<PlayerEntity, GetPlayerByUserViewModel>()
                                                   .ForMember(p => p.Player, d => d.MapFrom(z => z));
}
