// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Cysharp.Threading.Tasks;
using Gameplay.Configs;
using Gameplay.Player.Interfaces;
using Gameplay.Service;
using VContainer.Unity;

namespace Gameplay.Controllers
{
    public sealed class PlayerAbilityController : IInitializable, IDisposable, IPlayerAbilityController
    {
        public event Action<AbilityConfig> OnUseAbility;
        
        private readonly IPlayerInputService _inputService;
        private readonly IPlayer _player;
        private readonly AbilitySettings _abilitySettings;
        private readonly IAbilityResolverFactory _abilityFactory;

        private UniTask _currentAbilityProcess;
        
        public PlayerAbilityController(IPlayerInputService inputService, IPlayer player, AbilitySettings abilitySettings, IAbilityResolverFactory abilityFactory)
        {
            _inputService = inputService;
            _player = player;
            _abilitySettings = abilitySettings;
            _abilityFactory = abilityFactory;
        }

        public void Initialize()
        {
            _inputService.OnAction += OnPlayerAction;
        }

        public void Dispose()
        {
            _inputService.OnAction += OnPlayerAction;
        }
        
        private void OnPlayerAction(PlayerAction action)
        {
            switch (action)
            {
                case PlayerAction.Cast:
                    UseAbility();
                    break;
                case PlayerAction.NextSpell:
                    SetNextSpell();
                    break;
                case PlayerAction.PreviousSpell:
                    SetPreviousSpell();
                    break;
            }
        }

        private void UseAbility()
        {
            if (_currentAbilityProcess.Status < UniTaskStatus.Succeeded)
                return;
            
            var resolver = _abilityFactory.GetResolver(_player.CurrentSelectedAbility);
            _currentAbilityProcess = resolver.Resolve();
            OnUseAbility?.Invoke(_player.CurrentSelectedAbility);
        }

        private void SetNextSpell()
        {
            var currentAbility = _player.CurrentSelectedAbility;
            var index = _abilitySettings.AttackAbilities.IndexOf(currentAbility);
            index = index + 1 == _abilitySettings.AttackAbilities.Count ? 0 : index;
            _player.SetSelectedAbility(_abilitySettings.AttackAbilities[index]);
        }

        private void SetPreviousSpell()
        {
            var currentAbility = _player.CurrentSelectedAbility;
            var index = _abilitySettings.AttackAbilities.IndexOf(currentAbility);
            index = index - 1 >= 0 ? index : _abilitySettings.AttackAbilities.Count - 1;
            _player.SetSelectedAbility(_abilitySettings.AttackAbilities[index]);
        }
    }
}