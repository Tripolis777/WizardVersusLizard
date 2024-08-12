// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gameplay.Configs;
using UnityEngine;

namespace Gameplay.Ability.Component
{
    public class ProjectileBehavior : MonoBehaviour
    {
        private const float DefaultFlyDuration = 0.5f;
        
        [SerializeField]
        private Renderer _renderer;
        [SerializeField]
        private Transform _projectileObj;
        
        private ProjectileSettings _settings;
        private Vector3 _direction;

        private float _flyDuration;
        private bool _isCollided = false;
        
        public void Setup(ProjectileSettings settings, in Vector3 direction)
        {
            _settings = settings;
            _direction = direction;
        }

        public UniTask Fire() => Fly();

        private void OnCollisionEnter(Collision other)
        { 
            // TODO: check collision with enemies
        }

        private async UniTask Fly()
        {
            _flyDuration = DefaultFlyDuration;
            while (CanFly())
            {
                _projectileObj.position += _settings.Speed * _direction * Time.deltaTime;
                await UniTask.NextFrame();
            }   
        }

        private bool CanFly()
        {
            if (_isCollided)
                return false;
            
            if (_renderer.isVisible)
                return true;

            _flyDuration -= Time.deltaTime;
            if (_flyDuration > 0)
                return true;
            
            return false;
        }
    }
}