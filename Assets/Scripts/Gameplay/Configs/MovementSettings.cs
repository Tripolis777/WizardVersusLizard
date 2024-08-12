// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using UnityEngine;

namespace Gameplay.Configs
{
    [Serializable]
    public struct MovementSettings
    {
        [Min(0f)]
        public float Speed;
    }
}