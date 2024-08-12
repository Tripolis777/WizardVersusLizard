// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Gameplay.Ability.Component;
using Gameplay.Configs;

namespace Gameplay.Ability
{
    public interface IProjectileFactory
    {
        public ProjectileBehavior Create(ProjectileSettings settings);
    }
}