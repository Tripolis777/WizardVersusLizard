// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Gameplay.Configs
{
    [CreateAssetMenu(fileName = "AttackAbilityConfig", menuName = "Gameplay/Configs/AttackAbilityConfig")]
    public class AttackAbilityConfig : AbilityConfig
    {
        public float Damage;
        public float Range;
        public ProjectileSettings ProjectileSettings;
    }
}