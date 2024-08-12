// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Gameplay.Ability;
using Gameplay.Configs;

namespace Gameplay.Service
{
    public interface IAbilityResolverFactory
    {
        AbilityResolver GetResolver(AbilityConfig config);
    }
}