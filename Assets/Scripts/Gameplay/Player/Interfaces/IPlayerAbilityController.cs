// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Gameplay.Configs;

namespace Gameplay.Player.Interfaces
{
    public interface IPlayerAbilityController
    {
        event Action<AbilityConfig> OnUseAbility;
    }
}