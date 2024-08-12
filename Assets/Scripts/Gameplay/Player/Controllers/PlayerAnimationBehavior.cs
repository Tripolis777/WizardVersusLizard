// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Gameplay.Player.Interfaces;
using UnityEngine;
using VContainer.Unity;

namespace Gameplay.Controllers
{
    public class PlayerAnimationBehavior : IDisposable, IInitializable
    {
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        private readonly Animator _animator;
        private readonly Transform _transform;
        private readonly IPlayerMovement _playerMovement;
        
        public PlayerAnimationBehavior(IPlayerView playerView, IPlayerMovement playerMovement)
        {
            _animator = playerView.PlayerAnimator;
            _transform = playerView.PlayerTransform;
            _playerMovement = playerMovement;
        }

        public void Initialize()
        {
            _playerMovement.OnMoveBegin += OnMoveBegin;
            _playerMovement.OnMoveEnd += OnMoveEnd;
            _playerMovement.OnChangeDirection += OnChangeDirection;
        }
        
        public void Dispose()
        {
            _playerMovement.OnMoveBegin -= OnMoveBegin;
            _playerMovement.OnMoveEnd -= OnMoveEnd;
            _playerMovement.OnChangeDirection -= OnChangeDirection;
        }
        
        private void OnMoveBegin()
        {
            _animator.SetBool(IsRunning, true);   
        }
        
        private void OnMoveEnd()
        {
            _animator.SetBool(IsRunning, false);
        }
        
        private void OnChangeDirection(DirectionType direction)
        {
            var scale = _transform.localScale;
            scale.x = direction == DirectionType.Left ? -1 : 1;
            _transform.localScale = scale;
        }
    }
}