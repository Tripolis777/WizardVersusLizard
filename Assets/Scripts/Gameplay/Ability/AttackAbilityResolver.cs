// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Cysharp.Threading.Tasks;
using Gameplay.Configs;

namespace Gameplay.Ability
{
    public sealed class AttackAbilityResolver : AbilityResolver
    {
        private readonly IProjectileFactory _projectileFactory;
        private readonly AttackAbilityConfig _attackConfig;
        
        public AttackAbilityResolver(AttackAbilityConfig config, IProjectileFactory factory)
        {
            _attackConfig = config;
            _projectileFactory = factory;
        }

        public override async UniTask Resolve()
        {
            var behavior = _projectileFactory.Create(_attackConfig.ProjectileSettings);
            await behavior.Fire();
        }
    }
}