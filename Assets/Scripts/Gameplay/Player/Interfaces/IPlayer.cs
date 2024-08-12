// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Gameplay.Configs;

namespace Gameplay.Player.Interfaces
{
    public interface IPlayer
    {
        public float HealthPoints { get; }
        public float Defence { get; }
        public AbilityConfig CurrentSelectedAbility { get; }
        public IPlayerView View { get; }

        public void SetSelectedAbility(AbilityConfig ability);
    }
}