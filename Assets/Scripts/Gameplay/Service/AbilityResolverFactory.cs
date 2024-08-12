// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Gameplay.Ability;
using Gameplay.Configs;
using VContainer;

namespace Gameplay.Service
{
    public sealed class AbilityResolverFactory : IAbilityResolverFactory
    {
        private readonly IObjectResolver _objectResolver;
        
        public AbilityResolverFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }
        
        public AbilityResolver GetResolver(AbilityConfig config)
        {
            switch (config)
            {
                case AttackAbilityConfig attackAbilityConfig:
                    return new AttackAbilityResolver(attackAbilityConfig, _objectResolver.Resolve<IProjectileFactory>());
            }

            throw new ArgumentException($"Cannot resolve ability config - {config.name}");
        }
    }
}