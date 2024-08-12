// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Gameplay.Configs;
using Gameplay.Controllers;
using Gameplay.Player.Components;
using Gameplay.Player.Interfaces;
using Gameplay.Service;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Gameplay.Components.Scope
{
    public sealed class PlayerLifetimeScope : LifetimeScope
    {
        [SerializeField]
        private EntityConfig _playerConfig;
        [SerializeField]
        private PlayerView _playerView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_playerConfig.MovementSettings);
            builder.RegisterInstance(_playerConfig.HealthSettings);
            builder.RegisterInstance(_playerConfig.AbilitySettings);
            
            builder.RegisterComponent<IPlayerView>(_playerView);

            builder.Register<PlayerProjectileFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<AbilityResolverFactory>(Lifetime.Scoped).AsImplementedInterfaces();
            builder.Register<Controllers.Player>(Lifetime.Scoped).AsImplementedInterfaces();
            
            builder.RegisterEntryPoint<PlayerMovementController>(Lifetime.Scoped).As<IPlayerMovement>();
            builder.RegisterEntryPoint<PlayerAnimationBehavior>(Lifetime.Scoped);
            builder.RegisterEntryPoint<PlayerAbilityController>(Lifetime.Scoped);
        }
    }
}