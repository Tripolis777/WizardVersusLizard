// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Gameplay.Configs;
using Gameplay.Player.Interfaces;
using Gameplay.Service;
using UnityEngine;
using VContainer.Unity;

namespace Gameplay.Controllers
{
    public sealed class PlayerMovementController : IPlayerMovement, ITickable
    {
        public event Action OnMoveBegin;
        public event Action OnMoveEnd;
        public event Action<DirectionType> OnChangeDirection;
        
        private readonly IPlayerInputService _inputService;
        private readonly MovementSettings _moveSettings;
        private readonly Transform _playerTransform;

        private DirectionType _lastDirection;
        
        private bool _isMoving;
        private bool IsMoving
        {
            get => _isMoving;
            set
            {
                if (_isMoving == value)
                    return;
                
                _isMoving = value;
                if (_isMoving)
                    OnMoveBegin?.Invoke();
                else
                    OnMoveEnd?.Invoke();
            }
        }

        public DirectionType LastDirection => _lastDirection;
        
        public PlayerMovementController(IPlayerInputService inputService, MovementSettings moveSettings, IPlayerView playerView)
        {
            _moveSettings = moveSettings;
            _inputService = inputService;
            _playerTransform = playerView.PlayerTransform;
        }

        public void Tick()
        {
            OnMove(_inputService.MoveDirection);
        }
        
        private void OnMove(in Vector3 direction)
        {
            IsMoving = HasMovement(direction);
            if (IsMoving)
            {
                CheckChangeDirection(direction);
                _playerTransform.position += direction * _moveSettings.Speed * Time.deltaTime;
            }
        }

        private bool HasMovement(in Vector3 direction) => direction.sqrMagnitude > 0;

        private void CheckChangeDirection(in Vector3 direction)
        {
            var directionType = direction.x > 0 ? DirectionType.Right : DirectionType.Left;
            if (directionType == _lastDirection)
                return;

            _lastDirection = directionType;
            OnChangeDirection?.Invoke(directionType);
        }
    }
}