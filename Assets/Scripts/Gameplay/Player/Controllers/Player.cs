// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System.Linq;
using Gameplay.Configs;
using Gameplay.Player.Interfaces;

namespace Gameplay.Controllers
{
    public sealed class Player : IPlayer
    {
        public float HealthPoints { get; private set; }
        public float Defence { get; private set; }
        public AbilityConfig CurrentSelectedAbility { get; private set; }
        
        public IPlayerView View { get; }

        public Player(IPlayerView view, AbilitySettings settings)
        {
            View = view;
            CurrentSelectedAbility = settings.AttackAbilities.FirstOrDefault();
        } 
        
        public void SetSelectedAbility(AbilityConfig ability)
        {
            CurrentSelectedAbility = ability;
        }
    }
}