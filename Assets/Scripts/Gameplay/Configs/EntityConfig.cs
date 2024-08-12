// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Gameplay.Configs
{
    [CreateAssetMenu(fileName = "EntityConfig", menuName = "Gameplay/Configs/EntityConfig")]
    public class EntityConfig : ScriptableObject
    {
        public HealthSettings HealthSettings;
        public MovementSettings MovementSettings;
        public AbilitySettings AbilitySettings;
    }
}