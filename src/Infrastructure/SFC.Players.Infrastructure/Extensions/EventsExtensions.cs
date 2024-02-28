﻿using SFC.Data.Contracts.Models;
using SFC.Data.Contracts.Models.Common;
using SFC.Players.Domain.Common;
using SFC.Players.Domain.Entities.Data;

namespace SFC.Players.Infrastructure.Extensions;
public static class EventsExtensions
{
    public static T MapToDataEntity<T>(this DataValue value) where T : BaseDataEntity, new()
        => new() { Id = value.Id, Title = value.Title };

    public static StatType MapToDataEntity(this StatTypeDataValue value, StatCategory[] categories, StatSkill[] skills)
       => new() { Id = value.Id, Title = value.Title, Category = categories.FirstOrDefault(c => c.Id == value.CategoryId)!, Skill = skills.FirstOrDefault(c => c.Id == value.SkillId)! };
}
