// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using UnityEngine;

namespace Gameplay.Configs
{
    [Serializable]
    public struct HealthSettings
    {
        [Min(0f)]
        public float MaxHealthPoints;
        [Range(0f, 1f)]
        public float Defence;
    }
}