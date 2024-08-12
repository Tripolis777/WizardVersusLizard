// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Cysharp.Threading.Tasks;
using Gameplay.Ability;
using Gameplay.Ability.Component;
using Gameplay.Configs;
using Gameplay.Player.Interfaces;
using UnityEngine;

namespace Gameplay.Controllers
{
    public class PlayerProjectileFactory : IProjectileFactory
    {
        private readonly IPlayer _player;
        private readonly IPlayerMovement _playerMovement;
        
        public PlayerProjectileFactory(IPlayer player, IPlayerMovement playerMovement)
        {
            _player = player;
            _playerMovement = playerMovement;
        }
        
        public ProjectileBehavior Create(ProjectileSettings settings)
        {
            var pivot = _player.View.ProjectilePivot;
            var go = GameObject.Instantiate(settings.Prefab);
            go.transform.position = pivot.position;

            var behavior = go.GetComponent<ProjectileBehavior>();
            behavior.Setup(settings, _playerMovement.LastDirection == DirectionType.Left ? Vector3.left : Vector3.right);
            
            return behavior;
        }
    }
}