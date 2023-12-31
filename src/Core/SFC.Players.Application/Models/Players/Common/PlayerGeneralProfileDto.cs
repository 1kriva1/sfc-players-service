﻿using SFC.Players.Application.Common.Mappings;
using SFC.Players.Application.Models.Players.Common.Models;

namespace SFC.Players.Application.Models.Players.Common;

public class PlayerGeneralProfileDto: IMapFrom<PlayerGeneralProfileModel>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public PlayerPhotoDto? Photo { get; set; }

    public string? Biography { get; set; }

    public DateTime? Birthday { get; set; }

    public string City { get; set; } = null!;

    public bool FreePlay { get; set; }

    public IEnumerable<string> Tags { get; set; } = new List<string>();

    public PlayerAvailabilityDto Availability { get; set; } = null!;
}


