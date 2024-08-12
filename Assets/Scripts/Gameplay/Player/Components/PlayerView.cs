// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Gameplay.Player.Interfaces;
using UnityEngine;

namespace Gameplay.Player.Components
{
    public sealed class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField]
        private Transform _playerTransform;
        [SerializeField]
        private Transform _projectilePivot;
        [SerializeField]
        private Animator _animator;

        public Transform PlayerTransform => _playerTransform;
        public Transform ProjectilePivot => _projectilePivot;
        public Animator PlayerAnimator => _animator;
    }
}